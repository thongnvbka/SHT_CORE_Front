using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace WebAppBasite
{
    public class SUtility
    {
        public static string Obj2String(object obj)
        {
            if (obj == null)
                return string.Empty;
            try
            {
                return obj.ToString();
            }
            catch { return string.Empty; }
        }

        public static int Obj2Int(object obj)
        {
            if (obj == null)
                return 0;
            try
            {
                return Convert.ToInt32(obj.ToString().Replace(",", string.Empty), CultureInfo.InvariantCulture);
            }
            catch { return 0; }
        }
        public static string Sapo(object value, int words, bool noMore = false)
        {
            string sapo = Obj2String(value);
            if (string.IsNullOrEmpty(sapo) || sapo.Split(' ').Length < words)
                return sapo;

            string result = string.Empty;
            string[] arrWord = sapo.Split(' ');
            for (int i = 0; i < words; i++)
                result += arrWord[i] + " ";

            result = result.TrimEnd(' ') + (noMore ? "" : "...");

            return result;
        }
        public static string sizePattern = @"([0-9]+)x([0-9]+)";
        public static string domainThumb = Ultilities.Common.GetByKey("thumb_url");
        public static string GetThumbNail(object otitle, object oimg, string size, string className = "")
        {
            string title = Obj2String(otitle);
            string img = Obj2String(oimg);
            if (!img.Contains("."))
                return string.Empty;
            string pathImg = img;
            if (!img.StartsWith("http"))
                img = domainThumb + img;
            //img = domainThumb + (img.StartsWith("/") ? img.TrimStart('/') : img);

            var sizes = Regex.Match(size, sizePattern).Groups; ;
            int width = Obj2Int(sizes[1].Value);
            int height = Obj2Int(sizes[2].Value);
            string thumb = String.Format("{0}{1}", domainThumb, pathImg.Insert(pathImg.LastIndexOf("."), "_" + size));
            string result = String.Format("<img{2}  src=\"{0}\" title=\"{1}\" alt=\"{1}\" border=\"0\"{3}{4} />", thumb, HttpUtility.HtmlEncode(title),
                 string.IsNullOrWhiteSpace(className) ? "" : " class=\"" + className + "\""
                 , width == 0 ? "" : " width=\"" + width + "\"", height == 0 ? "" : " height=\"" + height + "\"");

            return result;
        }
        public static string GetThumbNailImg(object oimg, string size, string className = "")
        {
            string img = Obj2String(oimg);
            if (!img.Contains("."))
                return string.Empty;
            string pathImg = img;
            if (!img.StartsWith("http"))
                img = domainThumb + img;
            var sizes = Regex.Match(size, sizePattern).Groups; ;
            int width = Obj2Int(sizes[1].Value);
            int height = Obj2Int(sizes[2].Value);
            string thumb = String.Format("{0}/{1}", domainThumb, pathImg.Insert(pathImg.LastIndexOf("."), "_" + size));
            return thumb;
        }
        public static string RemoveIllegalCharacters(object input)
        {
            // cast the input to a string
            if (input == null)
                return string.Empty;
            string data = input.ToString();

            // replace illegal characters in XML documents with their entity references
            data = data.Replace("&", "&amp;");
            data = data.Replace("\"", "&quot;");
            data = data.Replace("'", "&apos;");
            data = data.Replace("<", "&lt;");
            data = data.Replace(">", "&gt;");

            return data;
        }
    }
}
