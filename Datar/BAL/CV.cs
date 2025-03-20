﻿namespace Datar.BAL
{
    public class CV
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public static readonly string HTML_Hide = "d-none";

        static CV()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public static string? UserName()
        {
            string? UserName = null;

            if (_httpContextAccessor.HttpContext.Session.GetString("UserName") != null)
            {
                UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName").ToString();
            }
            return UserName;
        }

        public static int? UserID()
        {
            int? UserID = null;

            if (_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                UserID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserID"));
            }
            return UserID;
        }
    }
}
