using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 日期帮助类
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// 将时间转为时间戳
        /// </summary>
        public static long ToTimeStamp(this DateTime dt)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
            var timeStamp = (long)(dt - startTime).TotalSeconds; // 相差秒数

            return timeStamp;
        }

        /// <summary>
        /// 将时间戳转为时间
        /// </summary>
        public static DateTime ToDateTime(long timeStamp)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddSeconds(timeStamp);

            return dt;
        }
    }
}
