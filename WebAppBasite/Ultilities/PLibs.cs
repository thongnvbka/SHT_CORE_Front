using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebAppBasite.Ultilities
{
    public class PLibs
    {
        public static int CountSundays(int year, int month)
        {
            var firstDay = new DateTime(year, month, 1);

            var day29 = firstDay.AddDays(28);
            var day30 = firstDay.AddDays(29);
            var day31 = firstDay.AddDays(30);

            if ((day29.Month == month && day29.DayOfWeek == DayOfWeek.Sunday)
            || (day30.Month == month && day30.DayOfWeek == DayOfWeek.Sunday)
            || (day31.Month == month && day31.DayOfWeek == DayOfWeek.Sunday))
            {
                return 5;
            }
            else
            {
                return 4;
            }
        }

        public static string CastMark(string src_mark, int kieu_mon_hoc, bool force_float = false)
        {
            src_mark = src_mark.Trim().ToUpper();
            if (src_mark == "") return src_mark;
            if (src_mark == "-1") return "";

            if (kieu_mon_hoc == 1)
            {
                // Kieu Tinh diem
                if (force_float)
                    return Math.Round((float.Parse(src_mark) / 10), 1).ToString("0.0");
                else
                    return Math.Round((float.Parse(src_mark) / 10), 1).ToString();
            }
            else if (kieu_mon_hoc == 2)
            {
                // Kieu Nhan xet
                if (src_mark == "0")
                    return "CĐ";
                else if (src_mark == "1" || src_mark == "10")
                    return "Đ";
                else if (src_mark == "2" || src_mark == "20")
                    return "M";
                else return src_mark;
            }
            else return src_mark;
        }

        //public static void SetSession(string name, object value)
        //{
        //    // Thêm tiền tố id của người dùng đăng nhập để đảm bảo không bị lẫn lộn khi nhiều người dùng trên 1 máy
        //    HttpContext.Current.Session[SysBaseInfor.GetIdNguoiDung() + "_" + name] = value;
        //}
        //public static object GetSession(string name)
        //{
        //    return HttpContext.Session[SysBaseInfor.GetIdNguoiDung() + "_" + name];
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserName">username (ma gv/ ma hs)</param>
        /// <param name="new_pass"></param>
        /// <returns></returns>
        //public static bool ResetPassword(string strUserName, string new_pass = "Abc@123")
        //{
        //    try
        //    {
        //        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //        var user = UserManager.FindByName(strUserName);
        //        if (user == null)
        //            user = UserManager.FindById(strUserName);
        //        if (user != null)
        //        {
        //            user.PasswordHash = UserManager.PasswordHasher.HashPassword(new_pass);
        //            UserManager.Update(user);
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// Ham nay de tach chuoi trong link cua youtube
        /// </summary>
        /// <param name="url">Duong dan den video cua youtube</param>
        /// <returns></returns>
        public static string TachYoutubeKey(string url = "")
        {
            var key = "";

            key = url.Substring(url.LastIndexOf("/") + 1);
            if (key.Contains("=")) key = key.Substring(key.LastIndexOf("=") + 1);
            if (key.Contains("?")) key = key.Substring(0, key.IndexOf("?"));
            if (key.Contains("&")) key = key.Substring(0, key.IndexOf("&"));

            return key.Trim();
        }
        public static string DetachedVideoIdYT(string url)
        {
            //var url = @"https://www.youtube.com/watch?v=Lvcyj1GfpGY&list=PLolZLFndMkSIYef2O64OLgT-njaPYDXqy";
            var uri = new Uri(url);

            // you can check host here => uri.Host <= "www.youtube.com"

            var query = HttpUtility.ParseQueryString(uri.Query);

            var videoId = string.Empty;

            if (query.AllKeys.Contains("v"))
            {
                videoId = query["v"];
            }
            else
            {
                videoId = uri.Segments.Last();
            }
            return videoId;
        }
    }
}
