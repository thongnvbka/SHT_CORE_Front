using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppBasite.Common.Lib
{
   public class Clibs
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            result = result.AddSeconds(unixTimeStamp + 25200.0).ToLocalTime();
            return result;
        }
        public static int DatetimeToTimestamp(DateTime d)
        {
            int num = (int)d.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return num - 25200;
        }
        public static int DatetimeToTimestampOrgin(DateTime d)
        {
            return (int)d.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
        public static DateTime UnixTimeStampToDateTimeOrgin(double unixTimeStamp)
        {
            DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            result = result.AddSeconds(unixTimeStamp).ToLocalTime();
            return result;
        }
    }
}
