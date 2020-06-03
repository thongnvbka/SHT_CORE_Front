using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppBasite.Common
{
    public static class Extension
    {
        #region "Convert"
        public static string ToDateRFC3987(this object obj)
        {
            try
            {
                DateTime dt = obj.ToDate();
                if (dt == DateTime.MinValue)
                {
                    return "";
                }
                else
                {
                    String _mm = dt.Month > 9 ? dt.Month.MapStr() : ("0" + dt.Month.MapStr());
                    String _dd = dt.Day > 9 ? dt.Day.MapStr() : ("0" + dt.Day.MapStr());
                    return dt.Year + "-" + _mm + "-" + _dd;
                }
            }
            catch
            {
                return String.Empty;
            }
        }
        public static string ToDateVietNam(this object obj)
        {
            try
            {
                DateTime dt = obj.ToDate();
                return dt == DateTime.MinValue ? "" : dt.Date.ToString("dd/MM/yyyy");
            }
            catch
            {
                return String.Empty;
            }
        }

        public static string ToDateTimeVietNam(this object obj)
        {
            try
            {
                DateTime dt = DateTime.Parse(obj.ToString());
                return dt == DateTime.MinValue ? "" : dt.ToString("yyyy-MM-dd'T'HH:mm:ss.fff");
            }
            catch
            {
                return String.Empty;
            }
        }
        public static int ToInt32(this object obj)
        {
            if (obj == null) return 0;
            int a = 0;
            int.TryParse(obj.ToString(), out a);
            return a;
            //try
            //{
            //    return Int32.Parse(obj.ToString());
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        public static Double ToDouble(this object obj)
        {
            try
            {
                return Double.Parse(obj.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static float ToFloat(this object obj)
        {
            try
            {
                if (obj == null || obj.ToString().Trim() == "") return -99999;
                else
                    return float.Parse(obj.ToString());
            }
            catch (Exception)
            {
                var obj_str = obj.ToString();
                throw;
            }
        }
        public static DateTime ToDate(this object obj)
        {
            try
            {
                return DateTime.Parse(obj.ToString()).Date;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Boolean ToBoolean(this object obj)
        {
            try
            {
                return (obj.ToString().ToUpper().Trim().Equals("TRUE") || obj.ToString().Trim().Equals("1")) ? true : false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int MapInt(this object obj)
        {
            try
            {
                return obj.ToInt32();
            }
            catch
            {
                return 0;
            }
        }
        public static string MapStr(this object obj, bool tienTe = false)
        {
            try
            {
                String result = "";
                result = obj.ToString();
                if (tienTe)
                {
                    result = string.Format("{0:0,0}", result.MapDouble());
                }
                return result;
            }
            catch
            {

                return String.Empty;
            }
        }
        public static Double MapDouble(this object obj, int lenght = 2)
        {
            try
            {
                return Math.Round(obj.ToDouble(), lenght);
            }
            catch
            {

                return 0;
            }
        }
        public static DateTime MapDate(this object obj)
        {
            try
            {
                return obj.ToDate();
            }
            catch
            {

                return DateTime.MinValue;
            }
        }
        public static string MapDateTime(this object obj)
        {
            try
            {
                return obj.ToDateTimeVietNam();
            }
            catch
            {

                return DateTime.MinValue.ToString("HH:mm:ss dd/MM/yyyy");
            }
        }
        public static Boolean MapBool(this object obj)
        {
            try
            {
                return obj.ToBoolean();
            }
            catch
            {

                return false;
            }
        }
        public static float MapFloat(this object obj)
        {
            try
            {
                return obj.ToFloat();
            }
            catch
            {
                return 0;
            }
        }
        #endregion


        public static string ConvertVNtoEN(string strText)
        {
            return RemoveUnicode(strText);
        }

        public static string RemoveUnicode(string text)
        {
            string[] arr_tohop = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
                "đ",
                "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                "í","ì","ỉ","ĩ","ị",
                "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                "ý","ỳ","ỷ","ỹ","ỵ"};
            string[] arr_dungsan = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
                "đ",
                "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                "í","ì","ỉ","ĩ","ị",
                "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                "ý","ỳ","ỷ","ỹ","ỵ"};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                "d",
                "e","e","e","e","e","e","e","e","e","e","e",
                "i","i","i","i","i",
                "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                "u","u","u","u","u","u","u","u","u","u","u",
                "y","y","y","y","y"};
            for (int i = 0; i < arr_tohop.Length; i++)
            {
                text = text.Replace(arr_tohop[i], arr2[i]);
                text = text.Replace(arr_tohop[i].ToUpper(), arr2[i].ToUpper());
            }
            for (int i = 0; i < arr_dungsan.Length; i++)
            {
                text = text.Replace(arr_dungsan[i], arr2[i]);
                text = text.Replace(arr_dungsan[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

 

        public static int Hoc_ky(DateTime Ngay)
        {
            int Ky = 0;
            if (Ngay.Month >= 9 && Ngay.Month <= 12)
            { Ky = 1; }
            else { Ky = 2; };
            return Ky;
        }

        public static string Nam_hoc(DateTime Ngay)
        {
            string Nam = "";
            if (Ngay.Month >= 9 && Ngay.Month <= 12)
            {
                Nam = Ngay.Year + "-" + (Ngay.Year + 1);
            }
            else
            {
                Nam = (Ngay.Year - 1) + "-" + Ngay.Year;
            }
            return Nam;
        }
    }
}
