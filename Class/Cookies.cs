using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class Cookies
    {
        public static string GETUSEID()
        {
            return GetCookies("USERID");
        }
        public static string GETUSENAM()
        {
            return GetCookies("USERNAME");
        }
        public static string GETBUSFUNC()
        {
            return GetCookies("USERGROUP");
        }
        public static string GETPASSWORD()
        {
            return GetCookies("TOKEN");
        }
        public static string GetCookies(string Key)
        {
            var Value = HttpContext.Current.Request.Cookies[Key]?.Value.Decrypt();
            return Value;
        }
        public static void PostCookies(string Key, string Value)
        {
            HttpContext.Current.Response.Cookies.Add(
            new HttpCookie(Key, Value.Encrypt())
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax
            });
        }
        public static string GetCookiesWithoutEnc(string Key)
        {
            var Value = HttpContext.Current.Request.Cookies[Key]?.Value;
            return Value;
        }
        public static void PostCookiesWithoutEnc(string Key, string Value)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(Key, Value));
        }
        public static void SetExpire(string key, double day)
        {
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(day);
        }
        public static void DeleteCookies(string Key)
        {
            HttpContext.Current.Response.Cookies[Key].Expires = DateTime.Now.AddDays(-1);
        }
    }
}