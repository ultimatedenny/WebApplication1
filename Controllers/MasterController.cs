using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Class;
using System.Configuration;

namespace WebApplication1.Controllers
{
    public class MasterController : Controller
    {
        ErrorController E = new ErrorController();
        public string CONNECTION = ConfigurationManager.ConnectionStrings["MAIN_CONNECTION"].ToString();
        string QUERY = string.Empty;

        //VIEW
        public new ActionResult User()
        {
            if (!string.IsNullOrEmpty(Cookies.GETUSEID()))
            {
                var data = IS_AUTHENTICATE("MASTER_USER");
                if (data.Count > 0)
                {
                    ViewBag.Username = Cookies.GETUSEID().ToUpper();
                    ViewBag.Group = Cookies.GETBUSFUNC().ToUpper();
                    return View();
                }
                else
                {
                    return RedirectToAction("ERROR403", "ERROR");
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Authentication");
            }
        }
        public ActionResult Plant()
        {
            if (!string.IsNullOrEmpty(Cookies.GETUSEID()))
            {
                var data = IS_AUTHENTICATE("MASTER_PLANT");
                if (data.Count > 0)
                {
                    ViewBag.Username = Cookies.GETUSEID().ToUpper();
                    ViewBag.Group = Cookies.GETBUSFUNC().ToUpper();
                    return View();
                }
                else
                {
                    return RedirectToAction("ERROR403", "ERROR");
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Authentication");
            }
        }
        public ActionResult Department()
        {
            if (!string.IsNullOrEmpty(Cookies.GETUSEID()))
            {
                var data = IS_AUTHENTICATE("MASTER_DEPARTMENT");
                if (data.Count > 0)
                {
                    ViewBag.Username = Cookies.GETUSEID().ToUpper();
                    ViewBag.Group = Cookies.GETBUSFUNC().ToUpper();
                    return View();
                }
                else
                {
                    return RedirectToAction("ERROR403", "ERROR");
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Authentication");
            }
        }
        public ActionResult Group()
        {
            if (!string.IsNullOrEmpty(Cookies.GETUSEID()))
            {
                var data = IS_AUTHENTICATE("MASTER_GROUP");
                if (data.Count > 0)
                {
                    ViewBag.Username = Cookies.GETUSEID().ToUpper();
                    ViewBag.Group = Cookies.GETBUSFUNC().ToUpper();
                    return View();
                }
                else
                {
                    return RedirectToAction("ERROR403", "ERROR");
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Authentication");
            }
        }
        public ActionResult Menu()
        {
            return View();
        }

        //CONTEOLLER COMMON
        public JsonResult WEB_GET_MENU_LIST()
        {
            var data = A_WEB_GET_MENU_LIST();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_DEPARTMENT()
        {
            var data = A_WEB_GET_DEPARTMENT();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_GROUP()
        {
            var data = A_WEB_GET_GROUP();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_PLANT()
        {
            var data = A_WEB_GET_PLANT();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_GET_CHECKBOX_MENU_LIST()
        {
            var data = A_WEB_GET_CHECKBOX_MENU_LIST();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

        //CONTROLLER USER
        public JsonResult WEB_GET_TABLE_USER()
        {
            var data = A_WEB_GET_TABLE_USER();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_ADD_USER(MASTERUSER MODEL)
        {
            var data = A_WEB_ADD_USER(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_DELETE_USER(MASTERUSER MODEL)
        {
            var data = A_WEB_DELETE_USER(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_DETAIL_USER(MASTERUSER MODEL)
        {
            var data = A_WEB_DETAIL_USER(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_EDIT_USER(MASTERUSER MODEL)
        {
            var data = A_WEB_EDIT_USER(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

        //CONTROLLER GROUP
        public JsonResult WEB_GET_TABLE_GROUP()
        {
            var data = A_WEB_GET_TABLE_GROUP();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_ADD_GROUP(MASTERGROUP MODEL)
        {
            var data = A_WEB_ADD_GROUP(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_DELETE_GROUP(MASTERGROUP MODEL)
        {
            var data = A_WEB_DELETE_GROUP(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_DETAIL_GROUP(MASTERGROUP MODEL)
        {
            var data = A_WEB_DETAIL_GROUP(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_EDIT_GROUP(MASTERGROUP MODEL)
        {
            var data = A_WEB_EDIT_GROUP(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

        //CONTROLLER DEPARTMENT
        public JsonResult WEB_GET_TABLE_DEPARTMENT()
        {
            var data = A_WEB_GET_TABLE_DEPARTMENT();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_ADD_DEPARTMENT(MASTERDEPARTMENT MODEL)
        {
            var data = A_WEB_ADD_DEPARTMENT(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_DELETE_DEPARTMENT(MASTERDEPARTMENT MODEL)
        {
            var data = A_WEB_DELETE_DEPARTMENT(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_DETAIL_DEPARTMENT(MASTERDEPARTMENT MODEL)
        {
            var data = A_WEB_DETAIL_DEPARTMENT(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_EDIT_DEPARTMENT(MASTERDEPARTMENT MODEL)
        {
            var data = A_WEB_EDIT_DEPARTMENT(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

        //CONTROLLER PLANT
        public JsonResult WEB_GET_TABLE_PLANT()
        {
            var data = A_WEB_GET_TABLE_PLANT();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_ADD_PLANT(MASTERPLANT MODEL)
        {
            var data = A_WEB_ADD_PLANT(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_DELETE_PLANT(MASTERPLANT MODEL)
        {
            var data = A_WEB_DELETE_PLANT(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_DETAIL_PLANT(MASTERPLANT MODEL)
        {
            var data = A_WEB_DETAIL_PLANT(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WEB_EDIT_PLANT(MASTERPLANT MODEL)
        {
            var data = A_WEB_EDIT_PLANT(MODEL);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }



        //ACTION COMMON
        public List<MenuListModel> A_WEB_GET_MENU_LIST()
        {
            try
            {
                DataTable dt = new DataTable();
                QUERY = @"
                    SELECT SEQUENCE, B.CODE, B.NAME, B.CONTROLLER,B.[VIEW], B.ICON, A.ISENABLE, PARENT
                    FROM DBTEST.DBO.LEVELMENU A
                    JOIN DBTEST.DBO.MENULIST B ON A.[GROUP] = B.[GROUP] AND A.MNUCOD = B.CODE 
                    AND A.BUSFUNC = @BUSINESSFUNCTIONS
                    ORDER BY SEQUENCE
                ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(QUERY, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@BUSINESSFUNCTIONS", Cookies.GETBUSFUNC());
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MenuListModel()
                             {
                                 SEQUENCE = row["SEQUENCE"].ToString(),
                                 CODE = row["CODE"].ToString(),
                                 NAME = row["NAME"].ToString(),
                                 CONTROLLER = row["CONTROLLER"].ToString(),
                                 VIEW = row["VIEW"].ToString(),
                                 ICON = row["ICON"].ToString(),
                                 ISENABLE = Convert.ToBoolean(row["ISENABLE"]),
                                 PARENT = row["PARENT"].ToString(),
                             }).ToList();
                return datas;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public PP<List<MASTERDEPARTMENT>> A_WEB_GET_DEPARTMENT()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT * FROM DEPARTMENT";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERDEPARTMENT()
                             {
                                 ID = row["ID"].ToString(),
                                 NAME = row["NAME"].ToString(),
                                 CREATEUSER = row["CREATEUSER"].ToString(),
                                 CREATEDATE = row["CREATEDATE"].ToString(),
                                 CHANGEUSER = row["CHANGEUSER"].ToString(),
                                 CHANGEDATE = row["CHANGEDATE"].ToString(),
                             }).ToList();

                if (datas.Count > 0)
                {
                    return new PP<List<MASTERDEPARTMENT>>
                    {
                        Result = true,
                        Message = "Success",
                        Data = datas,
                    };
                }
                else
                {
                    return new PP<List<MASTERDEPARTMENT>>
                    {
                        Result = false,
                        Message = "No Data",
                        Data = datas,
                    };
                }
            }
            catch (Exception ex)
            {
                return new PP<List<MASTERDEPARTMENT>>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null,
                };
            }
        }
        public PP<List<MASTERGROUP>> A_WEB_GET_GROUP()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT * FROM [GROUP]";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERGROUP()
                             {
                                 ID = row["ID"].ToString(),
                                 NAME = row["NAME"].ToString(),
                                 CREATEUSER = row["CREATEUSER"].ToString(),
                                 CREATEDATE = row["CREATEDATE"].ToString(),
                                 CHANGEUSER = row["CHANGEUSER"].ToString(),
                                 CHANGEDATE = row["CHANGEDATE"].ToString(),
                             }).ToList();

                if (datas.Count > 0)
                {
                    return new PP<List<MASTERGROUP>>
                    {
                        Result = true,
                        Message = "Success",
                        Data = datas,
                    };
                }
                else
                {
                    return new PP<List<MASTERGROUP>>
                    {
                        Result = false,
                        Message = "No Data",
                        Data = datas,
                    };
                }
            }
            catch (Exception ex)
            {
                return new PP<List<MASTERGROUP>>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null,
                };
            }
        }
        public PP<List<MASTERPLANT>> A_WEB_GET_PLANT()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT * FROM [PLANT]";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERPLANT()
                             {
                                 ID = row["ID"].ToString(),
                                 NAME = row["NAME"].ToString(),
                                 CREATEUSER = row["CREATEUSER"].ToString(),
                                 CREATEDATE = row["CREATEDATE"].ToString(),
                                 CHANGEUSER = row["CHANGEUSER"].ToString(),
                                 CHANGEDATE = row["CHANGEDATE"].ToString(),
                             }).ToList();

                if (datas.Count > 0)
                {
                    return new PP<List<MASTERPLANT>>
                    {
                        Result = true,
                        Message = "Success",
                        Data = datas,
                    };
                }
                else
                {
                    return new PP<List<MASTERPLANT>>
                    {
                        Result = false,
                        Message = "No Data",
                        Data = datas,
                    };
                }
            }
            catch (Exception ex)
            {
                return new PP<List<MASTERPLANT>>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null,
                };
            }
        }
        public List<MenuListModel> IS_AUTHENTICATE(string MENUCOD)
        {
            try
            {
                DataTable dt = new DataTable();
                QUERY = @"
                    SELECT SEQUENCE, B.CODE, B.NAME, B.CONTROLLER,B.[VIEW], B.ICON, A.ISENABLE, PARENT
                    FROM DBTEST.DBO.LEVELMENU A
                    JOIN DBTEST.DBO.MENULIST B ON A.[GROUP] = B.[GROUP] AND A.MNUCOD = B.CODE 
                    AND A.BUSFUNC = @BUSINESSFUNCTIONS AND B.CODE = @MENUCOD
                    ORDER BY SEQUENCE
                ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(QUERY, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@BUSINESSFUNCTIONS", Cookies.GETBUSFUNC());
                    command.Parameters.AddWithValue("@MENUCOD", MENUCOD);
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MenuListModel()
                             {
                                 SEQUENCE = row["SEQUENCE"].ToString(),
                                 CODE = row["CODE"].ToString(),
                                 NAME = row["NAME"].ToString(),
                                 CONTROLLER = row["CONTROLLER"].ToString(),
                                 VIEW = row["VIEW"].ToString(),
                                 ICON = row["ICON"].ToString(),
                                 ISENABLE = Convert.ToBoolean(row["ISENABLE"]),
                                 PARENT = row["PARENT"].ToString(),
                             }).ToList();
                return datas;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<MenuListModel> A_WEB_GET_CHECKBOX_MENU_LIST()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT CODE, NAME FROM DBTEST.DBO.MENULIST ORDER BY [SEQUENCE]";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MenuListModel()
                             {
                                 CODE = row["CODE"].ToString(),
                                 NAME = row["NAME"].ToString(),
                             }).ToList();

                return datas;
            }
            catch (Exception)
            {
                return null;
            }
        }


        //ACTION USER
        public List<MASTERUSER> A_WEB_GET_TABLE_USER()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT PLANTCODE, USERID, USERNAME, DEPARTMENT, 
                EMAIL, PHONE, BUSINESSFUNCTION, CREATEUSER, 
                CONVERT(VARCHAR(25), CREATEDATE ,120) CREATEDATE, CHANGEUSER, CHANGEDATE FROM [USER]";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERUSER()
                             {
                                 PLANTCODE = row["PLANTCODE"].ToString(),
                                 USERID = row["USERID"].ToString(),
                                 USERNAME = row["USERNAME"].ToString(),
                                 DEPARTMENT = row["DEPARTMENT"].ToString(),
                                 EMAIL = row["EMAIL"].ToString(),
                                 PHONE = row["PHONE"].ToString(),
                                 BUSINESSFUNCTION = row["BUSINESSFUNCTION"].ToString(),
                                 CREATEUSER = row["CREATEUSER"].ToString(),
                                 CREATEDATE = row["CREATEDATE"].ToString(),
                                 CHANGEUSER = row["CHANGEUSER"].ToString(),
                                 CHANGEDATE = row["CHANGEDATE"].ToString(),
                             }).ToList();
                return datas;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public PP<MASTERUSER> A_WEB_ADD_USER(MASTERUSER MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
	                        @PLANT nvarchar(max) = @PLANTS,
	                        @USERNAME nvarchar(max) = @USERNAMES,
	                        @EMAIL nvarchar(max) = @EMAILS,
	                        @USERID nvarchar(max) = @USERIDS,
	                        @PASSWORD nvarchar(max) = @PASSWORDS,
	                        @DEPARTMENT nvarchar(max) = @DEPARTMENTS,
	                        @GROUP nvarchar(max) = @GROUPS,
	                        @PHONE nvarchar(max) = @PHONES,
	                        @CREATEUSER nvarchar(max) = @CREATEUSERS

                        BEGIN
	                        IF NOT EXISTS (SELECT * FROM DBTEST.DBO.[USER] WHERE USERID = @USERID)
	                        BEGIN
		                        INSERT INTO DBTEST.DBO.[USER] (PLANTCODE, USERID, USERNAME, [PASSWORD], DEPARTMENT, EMAIL, PHONE, BUSINESSFUNCTION, CREATEUSER, CREATEDATE, ISWINDOWSAUTHENTICATION)
		                        VALUES (@PLANT, @USERID, @USERNAME, PWDENCRYPT(@PASSWORD), @DEPARTMENT, @EMAIL, @PHONE, @GROUP, @CREATEUSER, GETDATE(), 0)
		                        SELECT 1 AS RESULT, UPPER('USER '+@USERID+' SUCCESS CREATED !') as MESSAGE
	                        END
	                        ELSE
	                        BEGIN
	                        SELECT 0 AS RESULT, UPPER('USER '+@USERID+' ALREADY EXISTS !') as MESSAGE
	                        END
                        END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PLANTS", MODEL.PLANTCODE ?? "");
                    command.Parameters.AddWithValue("@USERNAMES", MODEL.USERNAME ?? "");
                    command.Parameters.AddWithValue("@EMAILS", MODEL.EMAIL);
                    command.Parameters.AddWithValue("@USERIDS", MODEL.USERID ?? "");
                    command.Parameters.AddWithValue("@PASSWORDS", MODEL.PASSWORD ?? "");
                    command.Parameters.AddWithValue("@DEPARTMENTS", MODEL.DEPARTMENT ?? "");
                    command.Parameters.AddWithValue("@GROUPS", MODEL.BUSINESSFUNCTION ?? "");
                    command.Parameters.AddWithValue("@PHONES", MODEL.PHONE ?? "");
                    command.Parameters.AddWithValue("@CREATEUSERS", Cookies.GetCookies("USERID") ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERUSER>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERUSER>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<MASTERUSER> A_WEB_EDIT_USER(MASTERUSER MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
                             @PLANT nvarchar(max) = @PLANTS,
                             @USERNAME nvarchar(max) = @USERNAMES,
                             @EMAIL nvarchar(max) = @EMAILS,
                             @USERID nvarchar(max) = @USERIDS,
                             @PASSWORD nvarchar(max) = @PASSWORDS,
                             @DEPARTMENT nvarchar(max) = @DEPARTMENTS,
                             @GROUP nvarchar(max) = @GROUPS,
                             @PHONE nvarchar(max) = @PHONES,
                             @CREATEUSER nvarchar(max) = @CREATEUSERS

                         BEGIN
                             IF EXISTS (SELECT * FROM DBTEST.DBO.[USER] WHERE USERID = @USERID)
                             BEGIN
		
		                        IF(@USERID != 'admin')
		                        BEGIN
			                        UPDATE DBTEST.DBO.[USER] SET
			                        PLANTCODE = @PLANT,
			                        USERNAME = @USERNAME,
			                        [PASSWORD] = PWDENCRYPT(@PASSWORD),
			                        DEPARTMENT = @DEPARTMENT,
			                        EMAIL = @EMAIL,
			                        PHONE = @PHONE,
			                        BUSINESSFUNCTION = @GROUP,
			                        CHANGEUSER = @CREATEUSER,
			                        CHANGEDATE = GETDATE()
			                        WHERE USERID = @USERID

			                        SELECT 1 AS RESULT, UPPER('USER '+@USERID+' SUCCESS EDITED !') as MESSAGE
		                        END
		                        ELSE
		                        BEGIN
			                        SELECT 0 AS RESULT, UPPER('USER '+@USERID+' CANNOT EDITED !') as MESSAGE
		                        END

                             END
                             ELSE
                             BEGIN
                             SELECT 0 AS RESULT, UPPER('USER '+@USERID+' NOT EXISTS !') as MESSAGE
                             END
                         END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PLANTS", MODEL.PLANTCODE ?? "");
                    command.Parameters.AddWithValue("@USERNAMES", MODEL.USERNAME ?? "");
                    command.Parameters.AddWithValue("@EMAILS", MODEL.EMAIL);
                    command.Parameters.AddWithValue("@USERIDS", MODEL.USERID ?? "");
                    command.Parameters.AddWithValue("@PASSWORDS", MODEL.PASSWORD ?? "");
                    command.Parameters.AddWithValue("@DEPARTMENTS", MODEL.DEPARTMENT ?? "");
                    command.Parameters.AddWithValue("@GROUPS", MODEL.BUSINESSFUNCTION ?? "");
                    command.Parameters.AddWithValue("@PHONES", MODEL.PHONE ?? "");
                    command.Parameters.AddWithValue("@CREATEUSERS", Cookies.GetCookies("USERID") ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERUSER>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERUSER>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<MASTERUSER> A_WEB_DELETE_USER(MASTERUSER MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
	                        @USERID nvarchar(max) = @USERIDS
                            BEGIN
                                IF EXISTS (SELECT * FROM DBTEST.DBO.[USER] WHERE USERID = @USERID)
                                BEGIN
		                            IF (@USERID != 'admin')
		                            BEGIN
			                            DELETE FROM DBTEST.DBO.[USER] WHERE USERID = @USERID
			                            SELECT 1 AS RESULT, UPPER('USER '+@USERID+' SUCCESS DELETED !') as MESSAGE
		                            END
		                            ELSE
		                            BEGIN
			                            SELECT 0 AS RESULT, UPPER('ADMIN USER CANNOT DELETE !') as MESSAGE
		                            END
        
                                END
                                ELSE
                                BEGIN
		                            SELECT 0 AS RESULT, UPPER('USER '+@USERID+' NOT EXISTS !') as MESSAGE
                                END
                        END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@USERIDS", MODEL.USERID ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERUSER>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERUSER>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public List<MASTERUSER> A_WEB_DETAIL_USER(MASTERUSER MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                        DECLARE
                        @USERID nvarchar(max) = @USERIDS
                        BEGIN
                        IF EXISTS (SELECT * FROM DBTEST.DBO.[USER] WHERE USERID = @USERID)
                        BEGIN
                            SELECT PLANTCODE, USERID, USERNAME, DEPARTMENT, 
                            EMAIL, PHONE, BUSINESSFUNCTION, CREATEUSER, 
                            CREATEDATE, CHANGEUSER, CHANGEDATE FROM DBTEST.DBO.[USER] WHERE USERID = @USERID
                        END
                        ELSE
                        BEGIN
                            SELECT 0 AS RESULT, UPPER('USER '+@USERID+' NOT EXISTS !') as MESSAGE
                        END
                        END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@USERIDS", MODEL.USERID ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERUSER()
                             {
                                 PLANTCODE = row["PLANTCODE"].ToString(),
                                 USERID = row["USERID"].ToString(),
                                 USERNAME = row["USERNAME"].ToString(),
                                 DEPARTMENT = row["DEPARTMENT"].ToString(),
                                 EMAIL = row["EMAIL"].ToString(),
                                 PHONE = row["PHONE"].ToString(),
                                 BUSINESSFUNCTION = row["BUSINESSFUNCTION"].ToString(),
                                 CREATEUSER = row["CREATEUSER"].ToString(),
                                 CREATEDATE = row["CREATEDATE"].ToString(),
                                 CHANGEUSER = row["CHANGEUSER"].ToString(),
                                 CHANGEDATE = row["CHANGEDATE"].ToString(),

                             }).ToList();

                return datas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //ACTION GROUP
        public List<MASTERGROUP> A_WEB_GET_TABLE_GROUP()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                SELECT 
                ID, 
                NAME, 
                CREATEUSER, 
                CONVERT(VARCHAR(25), CREATEDATE ,120) CREATEDATE,
                CHANGEUSER,
                CONVERT(VARCHAR(25), CHANGEDATE ,120) CHANGEDATE
                FROM [GROUP]";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERGROUP()
                             {
                                 ID = row["ID"].ToString(), 
                                 NAME = row["NAME"].ToString(),
                                 CREATEUSER = row["CREATEUSER"].ToString(),
                                 CREATEDATE = row["CREATEDATE"].ToString(),
                                 CHANGEUSER = row["CHANGEUSER"].ToString(),
                                 CHANGEDATE = row["CHANGEDATE"].ToString(),
                             }).ToList();
                return datas;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public PP<MASTERGROUP> A_WEB_ADD_GROUP(MASTERGROUP MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
                             @ID nvarchar(max) = @IDS,
                             @NAME nvarchar(max) = @NAMES,
                             @CREATEUSER nvarchar(max) = @CREATEUSERS

                         BEGIN
                             IF NOT EXISTS (SELECT * FROM DBTEST.DBO.[GROUP] WHERE ID = @ID)
                             BEGIN
                                 INSERT INTO DBTEST.DBO.[GROUP] (ID, [NAME], CREATEUSER, CREATEDATE)
                                 VALUES (@ID, @NAME, @CREATEUSER, GETDATE())
                                 SELECT 1 AS RESULT, UPPER('USER '+@ID+' SUCCESS CREATED !') as MESSAGE
                             END
                             ELSE
                             BEGIN
                             SELECT 0 AS RESULT, UPPER('GROUP '+@ID+' ALREADY EXISTS !') as MESSAGE
                             END
                         END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    command.Parameters.AddWithValue("@NAMES", MODEL.NAME ?? "");
                    command.Parameters.AddWithValue("@CREATEUSERS", Cookies.GetCookies("USERID") ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERGROUP>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERGROUP>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<MASTERGROUP> A_WEB_EDIT_GROUP(MASTERGROUP MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
                          @ID nvarchar(max) = @IDS,
                          @NAME nvarchar(max) = @NAMES,
                          @CREATEUSER nvarchar(max) = @CREATEUSERS

                      BEGIN
                          IF EXISTS (SELECT * FROM DBTEST.DBO.[GROUP] WHERE ID = @ID)
                          BEGIN
		
                             IF(@ID != 'Administrator')
                             BEGIN
                                 UPDATE DBTEST.DBO.[GROUP] SET
                                 [NAME] = @NAME,
                                 CHANGEUSER = @CREATEUSER,
                                 CHANGEDATE = GETDATE()
                                 WHERE ID = @ID

                                 SELECT 1 AS RESULT, UPPER('GROUP '+@ID+' SUCCESS EDITED !') as MESSAGE
                             END
                             ELSE
                             BEGIN
                                 SELECT 0 AS RESULT, UPPER('GROUP '+@ID+' CANNOT EDITED !') as MESSAGE
                             END

                          END
                          ELSE
                          BEGIN
                          SELECT 0 AS RESULT, UPPER('GROUP '+@ID+' NOT EXISTS !') as MESSAGE
                          END
                      END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    command.Parameters.AddWithValue("@NAMES", MODEL.NAME ?? "");
                    command.Parameters.AddWithValue("@CREATEUSERS", Cookies.GetCookies("USERID") ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERGROUP>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERGROUP>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<MASTERGROUP> A_WEB_DELETE_GROUP(MASTERGROUP MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
                             @ID nvarchar(max) = @IDS
                             BEGIN
                                 IF EXISTS (SELECT * FROM DBTEST.DBO.[GROUP] WHERE ID = @ID)
                                 BEGIN
                                     IF (@ID != 'Administrator')
                                     BEGIN
                                         DELETE FROM DBTEST.DBO.[GROUP] WHERE ID = @ID
                                         SELECT 1 AS RESULT, UPPER('USER '+@ID+' SUCCESS DELETED !') as MESSAGE
                                     END
                                     ELSE
                                     BEGIN
                                         SELECT 0 AS RESULT, UPPER('GROUP CANNOT DELETE !') as MESSAGE
                                     END
        
                                 END
                                 ELSE
                                 BEGIN
                                     SELECT 0 AS RESULT, UPPER('GROUP '+@ID+' NOT EXISTS !') as MESSAGE
                                 END
                         END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERGROUP>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERGROUP>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public List<MASTERGROUP> A_WEB_DETAIL_GROUP(MASTERGROUP MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                        DECLARE
                        @ID nvarchar(max) = @IDS
                        BEGIN
                        IF EXISTS (SELECT * FROM DBTEST.DBO.[GROUP] WHERE ID = @ID)
                        BEGIN
                        SELECT ID, [NAME] FROM DBTEST.DBO.[GROUP] WHERE ID = @ID
                        END
                        ELSE
                        BEGIN
                        SELECT 0 AS RESULT, UPPER('GROUP '+@ID+' NOT EXISTS !') as MESSAGE
                        END
                        END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERGROUP()
                             {
                                 ID = row["ID"].ToString(),
                                 NAME = row["NAME"].ToString(),
                                 

                             }).ToList();

                return datas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //ACTION DEPARTMENT
        public List<MASTERDEPARTMENT> A_WEB_GET_TABLE_DEPARTMENT()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT 
                ID, 
                NAME, 
                CREATEUSER, 
                CONVERT(VARCHAR(25), CREATEDATE ,120) CREATEDATE,
                CHANGEUSER,
                CONVERT(VARCHAR(25), CHANGEDATE ,120) CHANGEDATE
                FROM [DEPARTMENT]";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERDEPARTMENT()
                             {
                                 ID = row["ID"].ToString(),
                                 NAME = row["NAME"].ToString(),
                                 CREATEUSER = row["CREATEUSER"].ToString(),
                                 CREATEDATE = row["CREATEDATE"].ToString(),
                                 CHANGEUSER = row["CHANGEUSER"].ToString(),
                                 CHANGEDATE = row["CHANGEDATE"].ToString(),
                             }).ToList();
                return datas;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public PP<MASTERDEPARTMENT> A_WEB_ADD_DEPARTMENT(MASTERDEPARTMENT MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
                             @ID nvarchar(max) = @IDS,
                             @NAME nvarchar(max) = @NAMES,
                             @CREATEUSER nvarchar(max) = @CREATEUSERS

                         BEGIN
                             IF NOT EXISTS (SELECT * FROM DBTEST.DBO.[DEPARTMENT] WHERE ID = @ID)
                             BEGIN
                                 INSERT INTO DBTEST.DBO.[DEPARTMENT] (ID, [NAME], CREATEUSER, CREATEDATE)
                                 VALUES (@ID, @NAME, @CREATEUSER, GETDATE())
                                 SELECT 1 AS RESULT, UPPER('USER '+@ID+' SUCCESS CREATED !') as MESSAGE
                             END
                             ELSE
                             BEGIN
                             SELECT 0 AS RESULT, UPPER('DEPARTMENT '+@ID+' ALREADY EXISTS !') as MESSAGE
                             END
                         END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    command.Parameters.AddWithValue("@NAMES", MODEL.NAME ?? "");
                    command.Parameters.AddWithValue("@CREATEUSERS", Cookies.GetCookies("USERID") ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERDEPARTMENT>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERDEPARTMENT>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<MASTERDEPARTMENT> A_WEB_EDIT_DEPARTMENT(MASTERDEPARTMENT MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
                          @ID nvarchar(max) = @IDS,
                          @NAME nvarchar(max) = @NAMES,
                          @CREATEUSER nvarchar(max) = @CREATEUSERS

                      BEGIN
                          IF EXISTS (SELECT * FROM DBTEST.DBO.[DEPARTMENT] WHERE ID = @ID)
                          BEGIN
		
                             IF(@ID != 'Administrator')
                             BEGIN
                                 UPDATE DBTEST.DBO.[DEPARTMENT] SET
                                 [NAME] = @NAME,
                                 CHANGEUSER = @CREATEUSER,
                                 CHANGEDATE = GETDATE()
                                 WHERE ID = @ID

                                 SELECT 1 AS RESULT, UPPER('DEPARTMENT '+@ID+' SUCCESS EDITED !') as MESSAGE
                             END
                             ELSE
                             BEGIN
                                 SELECT 0 AS RESULT, UPPER('DEPARTMENT '+@ID+' CANNOT EDITED !') as MESSAGE
                             END

                          END
                          ELSE
                          BEGIN
                          SELECT 0 AS RESULT, UPPER('DEPARTMENT '+@ID+' NOT EXISTS !') as MESSAGE
                          END
                      END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    command.Parameters.AddWithValue("@NAMES", MODEL.NAME ?? "");
                    command.Parameters.AddWithValue("@CREATEUSERS", Cookies.GetCookies("USERID") ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERDEPARTMENT>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERDEPARTMENT>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<MASTERDEPARTMENT> A_WEB_DELETE_DEPARTMENT(MASTERDEPARTMENT MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
                             @ID nvarchar(max) = @IDS
                             BEGIN
                                 IF EXISTS (SELECT * FROM DBTEST.DBO.[DEPARTMENT] WHERE ID = @ID)
                                 BEGIN
                                     IF (@ID != 'Administrator')
                                     BEGIN
                                         DELETE FROM DBTEST.DBO.[DEPARTMENT] WHERE ID = @ID
                                         SELECT 1 AS RESULT, UPPER('USER '+@ID+' SUCCESS DELETED !') as MESSAGE
                                     END
                                     ELSE
                                     BEGIN
                                         SELECT 0 AS RESULT, UPPER('DEPARTMENT CANNOT DELETE !') as MESSAGE
                                     END
        
                                 END
                                 ELSE
                                 BEGIN
                                     SELECT 0 AS RESULT, UPPER('DEPARTMENT '+@ID+' NOT EXISTS !') as MESSAGE
                                 END
                         END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERDEPARTMENT>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERDEPARTMENT>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public List<MASTERDEPARTMENT> A_WEB_DETAIL_DEPARTMENT(MASTERDEPARTMENT MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                        DECLARE
                        @ID nvarchar(max) = @IDS
                        BEGIN
                        IF EXISTS (SELECT * FROM DBTEST.DBO.[DEPARTMENT] WHERE ID = @ID)
                        BEGIN
                        SELECT ID, [NAME] FROM DBTEST.DBO.[DEPARTMENT] WHERE ID = @ID
                        END
                        ELSE
                        BEGIN
                        SELECT 0 AS RESULT, UPPER('DEPARTMENT '+@ID+' NOT EXISTS !') as MESSAGE
                        END
                        END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERDEPARTMENT()
                             {
                                 ID = row["ID"].ToString(),
                                 NAME = row["NAME"].ToString(),


                             }).ToList();

                return datas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //ACTION PLANT
        public List<MASTERPLANT> A_WEB_GET_TABLE_PLANT()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT 
                ID, 
                NAME, 
                CREATEUSER, 
                CONVERT(VARCHAR(25), CREATEDATE ,120) CREATEDATE,
                CHANGEUSER,
                CONVERT(VARCHAR(25), CHANGEDATE ,120) CHANGEDATE
                FROM [PLANT]";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERPLANT()
                             {
                                 ID = row["ID"].ToString(),
                                 NAME = row["NAME"].ToString(),
                                 CREATEUSER = row["CREATEUSER"].ToString(),
                                 CREATEDATE = row["CREATEDATE"].ToString(),
                                 CHANGEUSER = row["CHANGEUSER"].ToString(),
                                 CHANGEDATE = row["CHANGEDATE"].ToString(),
                             }).ToList();
                return datas;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public PP<MASTERPLANT> A_WEB_ADD_PLANT(MASTERPLANT MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
                             @ID nvarchar(max) = @IDS,
                             @NAME nvarchar(max) = @NAMES,
                             @CREATEUSER nvarchar(max) = @CREATEUSERS

                         BEGIN
                             IF NOT EXISTS (SELECT * FROM DBTEST.DBO.[PLANT] WHERE ID = @ID)
                             BEGIN
                                 INSERT INTO DBTEST.DBO.[PLANT] (ID, [NAME], CREATEUSER, CREATEDATE)
                                 VALUES (@ID, @NAME, @CREATEUSER, GETDATE())
                                 SELECT 1 AS RESULT, UPPER('USER '+@ID+' SUCCESS CREATED !') as MESSAGE
                             END
                             ELSE
                             BEGIN
                             SELECT 0 AS RESULT, UPPER('PLANT '+@ID+' ALREADY EXISTS !') as MESSAGE
                             END
                         END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    command.Parameters.AddWithValue("@NAMES", MODEL.NAME ?? "");
                    command.Parameters.AddWithValue("@CREATEUSERS", Cookies.GetCookies("USERID") ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERPLANT>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERPLANT>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<MASTERPLANT> A_WEB_EDIT_PLANT(MASTERPLANT MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
                          @ID nvarchar(max) = @IDS,
                          @NAME nvarchar(max) = @NAMES,
                          @CREATEUSER nvarchar(max) = @CREATEUSERS

                      BEGIN
                          IF EXISTS (SELECT * FROM DBTEST.DBO.[PLANT] WHERE ID = @ID)
                          BEGIN
		
                             IF(@ID != 'Administrator')
                             BEGIN
                                 UPDATE DBTEST.DBO.[PLANT] SET
                                 [NAME] = @NAME,
                                 CHANGEUSER = @CREATEUSER,
                                 CHANGEDATE = GETDATE()
                                 WHERE ID = @ID

                                 SELECT 1 AS RESULT, UPPER('PLANT '+@ID+' SUCCESS EDITED !') as MESSAGE
                             END
                             ELSE
                             BEGIN
                                 SELECT 0 AS RESULT, UPPER('PLANT '+@ID+' CANNOT EDITED !') as MESSAGE
                             END

                          END
                          ELSE
                          BEGIN
                          SELECT 0 AS RESULT, UPPER('PLANT '+@ID+' NOT EXISTS !') as MESSAGE
                          END
                      END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    command.Parameters.AddWithValue("@NAMES", MODEL.NAME ?? "");
                    command.Parameters.AddWithValue("@CREATEUSERS", Cookies.GetCookies("USERID") ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERPLANT>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERPLANT>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public PP<MASTERPLANT> A_WEB_DELETE_PLANT(MASTERPLANT MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                       DECLARE
                             @ID nvarchar(max) = @IDS
                             BEGIN
                                 IF EXISTS (SELECT * FROM DBTEST.DBO.[PLANT] WHERE ID = @ID)
                                 BEGIN
                                     IF (@ID != 'Administrator')
                                     BEGIN
                                         DELETE FROM DBTEST.DBO.[PLANT] WHERE ID = @ID
                                         SELECT 1 AS RESULT, UPPER('USER '+@ID+' SUCCESS DELETED !') as MESSAGE
                                     END
                                     ELSE
                                     BEGIN
                                         SELECT 0 AS RESULT, UPPER('PLANT CANNOT DELETE !') as MESSAGE
                                     END
        
                                 END
                                 ELSE
                                 BEGIN
                                     SELECT 0 AS RESULT, UPPER('PLANT '+@ID+' NOT EXISTS !') as MESSAGE
                                 END
                         END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                return new PP<MASTERPLANT>
                {
                    Result = Convert.ToBoolean(dt.Rows[0]["RESULT"]),
                    Message = dt.Rows[0]["MESSAGE"].ToString(),
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new PP<MASTERPLANT>
                {
                    Result = false,
                    Message = ex.Message.ToString(),
                    Data = null
                };
            }
        }
        public List<MASTERPLANT> A_WEB_DETAIL_PLANT(MASTERPLANT MODEL)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
                        DECLARE
                        @ID nvarchar(max) = @IDS
                        BEGIN
                        IF EXISTS (SELECT * FROM DBTEST.DBO.[PLANT] WHERE ID = @ID)
                        BEGIN
                        SELECT ID, [NAME] FROM DBTEST.DBO.[PLANT] WHERE ID = @ID
                        END
                        ELSE
                        BEGIN
                        SELECT 0 AS RESULT, UPPER('PLANT '+@ID+' NOT EXISTS !') as MESSAGE
                        END
                        END
                    ";
                using (SqlConnection connection = new SqlConnection(CONNECTION))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IDS", MODEL.ID ?? "");
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dt);
                    command.Connection.Close();
                }
                var datas = (from row in dt.AsEnumerable()
                             select new MASTERPLANT()
                             {
                                 ID = row["ID"].ToString(),
                                 NAME = row["NAME"].ToString(),


                             }).ToList();

                return datas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}