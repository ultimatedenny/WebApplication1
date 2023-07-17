using Microsoft.Win32.SafeHandles;
using SimpleImpersonation;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using WebApplication1.Class;
using WebApplication1.Models;
using System.Configuration;

namespace WebApplication1.Controllers
{
    public class AuthenticationController : Controller
    {
        public string CONNECTION = ConfigurationManager.ConnectionStrings["MAIN_CONNECTION"].ToString();
        string QUERY = string.Empty;
        [AllowAnonymous]
        public ActionResult SignIn()
        {
            if (Cookies.GETUSEID() != null)
            {
                ViewBag.USERNAME = Cookies.GetCookies("USERNAME");
                ViewBag.USERGROUP = Cookies.GetCookies("USERGROUP");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    var result = TrySignIn(model.UseId, model.Password);
                    if (result.Result == true)
                    {
                        Cookies.PostCookies("USERID", result.Data.USERID.ToString());
                        Cookies.PostCookies("USERNAME", result.Data.USERNAME.ToString());
                        Cookies.PostCookies("USERGROUP", result.Data.BUSINESSFUNCTION.ToString());
                        Cookies.SetExpire("USERID", 1);
                        Cookies.SetExpire("USERNAME", 1);
                        Cookies.SetExpire("USERGROUP", 1);
                        TempData["SUCCESS"] = result.Message.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["SUCCESS"] = result.Message.ToString();
                        return View(model);
                    }
                }
            }
            catch(Exception ex)
            {
                TempData["ERROR"] = "" + ex.Message.ToString() + "";
                return View();
            }
        }
        public PP<AccountModel> TrySignIn(string USERID, string PASSWORD)
        {
            try
            {
                QUERY = @"
                    DECLARE @USERID NVARCHAR(MAX)	= @USERIDS
                    DECLARE @USERPASS NVARCHAR(MAX) = @PASSWORDS
                    SELECT TOP 1 PLANTCODE AS PLANT,USERID,
                    USERNAME,[PASSWORD],BUSINESSFUNCTION, ISNULL(ISWINDOWSAUTHENTICATION,0) AS ISWINDOW,
                    ISNULL(WINDOWSAUTH,0) AS WINDOWSID
                    ,DOMAINNAME,
                    PWDCOMPARE(@USERPASS,[PASSWORD]) CHKPASS, '1' AS EXPIREDAY FROM [USER]
                    WHERE USERID = @USERID AND ISACTIVE = 1
                ";
                DataTable dt = new DataTable();
                using (SqlConnection CON = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(QUERY, CON);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@USERIDS", USERID);
                    command.Parameters.AddWithValue("@PASSWORDS", PASSWORD);
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var DATA = (from row in dt.AsEnumerable()
                            select new AccountModel()
                            {
                                PLANT = row["PLANT"].ToString(),
                                USERID = row["USERID"].ToString(),
                                USERNAME = row["USERNAME"].ToString(),
                                BUSINESSFUNCTION = row["BUSINESSFUNCTION"].ToString(),
                                ISWINDOW = row["ISWINDOW"].ToBoolean(),
                                WINDOWSID = row["WINDOWSID"].ToString(),
                                DOMAINNAME = row["DOMAINNAME"].ToString(),
                                CHKPASS = row["CHKPASS"].ToBoolean(),
                                EXPIREDAY = Convert.ToDouble(row["EXPIREDAY"]),
                            }).FirstOrDefault();

                if (DATA != null)
                {
                    if (DATA.ISWINDOW)
                    {
                        UserCredentials credentials = new UserCredentials(DATA.DOMAINNAME, DATA.USERID, PASSWORD);
                        SafeAccessTokenHandle userHandle = credentials.LogonUser(LogonType.Interactive);
                        WindowsIdentity.RunImpersonated(userHandle, () => {

                        });
                        UpdateLastLogin(DATA.USERID);
                        return new PP<AccountModel>
                        {
                            Result = true,
                            Message = "Sign in success",
                            Data = DATA
                        };
                    }
                    else
                    {
                        if (DATA.CHKPASS)
                        {
                            UpdateLastLogin(DATA.USERID);
                            return new PP<AccountModel>
                            {
                                Result = true,
                                Message = "Sign in success",
                                Data = DATA
                            };
                        }
                        else
                        {
                            return new PP<AccountModel>
                            {
                                Result = false,
                                Message = "The user name or password is incorrect",
                                Data = null
                            };
                        }
                    }
                }
                else
                {
                    return new PP<AccountModel>
                    {
                        Result = false,
                        Message = "Failed, user not found",
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new PP<AccountModel>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public bool UpdateLastLogin(string USERID)
        {
            try
            {
                QUERY = @"DECLARE @USERID NVARCHAR(MAX)	= '@USERIDS'
                UPDATE [USER] SET LASTLOGINDATE=GETDATE() WHERE USERID = @USERID";
                using (SqlConnection CON = new SqlConnection(CONNECTION))
                {
                    DataTable dt = new DataTable();
                    SqlCommand command = new SqlCommand(QUERY, CON);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@USERIDS", USERID);
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [AllowAnonymous]
        public ActionResult SignOut()
        {
            try
            {
                string[] myCookies = Request.Cookies.AllKeys;
                foreach (string cookie in myCookies)
                {
                    //string SITENAME = ConfigurationManager.AppSettings["SITENAME"].ToString();
                    //if (cookie.Contains(SITENAME))
                    //{
                    //    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                    //}
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }
                return RedirectToAction("SignIn", "Authentication");
            }
            catch (Exception)
            {
                return RedirectToAction("SignIn", "Authentication");
            }
        }
    }
}