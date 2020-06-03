using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppBasite.App_Code
{
    public class PLibs
    {
        private ConfigSetting ConfigSetting { get; set; }

        public const string uniChars =
           "àáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ";

        public const string KoDauChars =
                "aaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIOOOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU";

        public static string UnicodeToKoDau(string s)
        {
            string retVal = String.Empty;
            int pos;
            for (int i = 0; i < s.Length; i++)
            {
                pos = uniChars.IndexOf(s[i].ToString());
                if (pos >= 0)
                    retVal += KoDauChars[pos];
                else
                    retVal += s[i];
            }
            return retVal;
        }
        public static string UnicodeToKoDauAndGach(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;
            string strChar = "abcdefghijklmnopqrstxyzuvxw0123456789 ";
            s = UnicodeToKoDau(s.ToLower().Trim());
            string sReturn = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (strChar.IndexOf(s[i]) > -1)
                {
                    if (s[i] != ' ')
                        sReturn += s[i];
                    else if (i > 0 && s[i - 1] != ' ' && s[i - 1] != '-')
                        sReturn += "-";
                }
            }
            return sReturn.Replace("--", "-");

        }
        public static string GetAdminUrl()
        {
            return Ultilities.Common.GetByKey("backend_url");
        }
        public static string GetDhtnUrl()
        {
            return ConfigurationManager.AppSettings["qlvbdhtn_url"];
        }
        public static string CkImg404(string img)
        {
            if (img == null || img.Trim() == "")
                return "UITheme/assets/global/img/no-image.png";
            else return img.Trim();
        }
        public static string Split(string src, int max_len, bool fixed_len = false)
        {
            src = src.Trim();
            var s = src;
            if (max_len > 0 && s.Length > max_len) s = s.Substring(0, max_len);
            else return s;

            if (fixed_len) return s;
            else if (src[max_len] == ' ') return s + "&hellip;";
            else
                return s.Substring(0, s.LastIndexOf(' ')) + "&hellip;";
        }
    }
}