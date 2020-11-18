using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Common
{
    public class CookieHelper
    {
        private const string _PrevFix = "OrderManagerWeb_";

        #region 添加一个Cookie
        /// <summary>
        /// 添加一个Cookie
        /// 2020-11-03 14:40
        /// </summary>
        /// <param name="CookieName">cookie名</param>
        /// <param name="CookieValue">cookie值</param>
        /// <param name="Expires">过期时间 DateTime</param>
        public static void SetCookie(string CookieName, string CookieValue, DateTime Expires)
        {
            HttpCookie Cookie = new HttpCookie(_PrevFix+CookieName)

            {
                Value = HttpUtility.UrlEncode(CookieValue),
                Expires = Expires
            };
            HttpContext.Current.Response.Cookies.Add(Cookie);
        }

       
        #endregion

        #region 清除指定Cookie
        public static void ClaeaCookie(string CookieName)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies[_PrevFix + CookieName];
            if(Cookie != null)
            {
                Cookie.Expires = DateTime.Now.AddMinutes(-10);
                HttpContext.Current.Response.Cookies.Add(Cookie);
            }           
        }
        #endregion

        #region 获取指定Cookie值
        /// <summary>
        /// Eric
        /// </summary>
        /// <param name="CookieName"></param>
        /// <returns></returns>
        public static string GetCookieValue(string CookieName)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies[_PrevFix + CookieName];
            string Str = string.Empty;
            if (Cookie != null)
            {
                Str = HttpUtility.UrlDecode(Cookie.Value);
            }
            return Str;
        }
        #endregion

    }
}