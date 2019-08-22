using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public static class StringHelper
    {
        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>bool</returns>
        public static bool IsNullOrEmpty(this string s) => String.IsNullOrEmpty(s);
        /// <summary>
        /// 检查字符串中是否包含列表中关键词,不区分大小写
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="keys">关键词列表</param>
        /// <returns></returns>
        public static bool Contains(this string s, IEnumerable<string> keys) => Regex.IsMatch(s.ToLower(), String.Join("|", keys).ToLower());
        /// <summary>
        /// 检查字符串中是否包含列表中关键词,区分大小写
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="keys">关键词列表</param>
        /// <returns></returns>
        public static bool ContainsStrict(this string s, IEnumerable<string> keys) => Regex.IsMatch(s, String.Join("|", keys));

        /// <summary>
        /// 字符串转时间
        /// </summary>
        /// <param name="value">源字符串</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value)
        {
            DateTime.TryParse(value, out var result);
            return result;
        }

        #region 字符串转数字

        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>int类型的数字</returns>
        public static int ToInt32(this string s)
        {
            Int32.TryParse(s, out int result);
            return result;
        }

        /// <summary>
        /// 字符串转long
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>int类型的数字</returns>
        public static long ToInt64(this string s)
        {
            Int64.TryParse(s, out var result);
            return result;
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>double类型的数据</returns>
        public static double ToDouble(this string s)
        {
            Double.TryParse(s, out var result);
            return result;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>int类型的数字</returns>
        public static decimal ToDecimal(this string s)
        {
            Decimal.TryParse(s, out var result);
            return result;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>int类型的数字</returns>
        public static decimal ToDecimal(this double s)
        {
            return new decimal(s);
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>double类型的数据</returns>
        public static double ToDouble(this decimal s)
        {
            return (double)s;
        }

        /// <summary>
        /// 将double转换成int
        /// </summary>
        /// <param name="num">double类型</param>
        /// <returns>int类型</returns>
        public static int ToInt32(this double num)
        {
            return (int)Math.Floor(num);
        }

        /// <summary>
        /// 将double转换成int
        /// </summary>
        /// <param name="num">double类型</param>
        /// <returns>int类型</returns>
        public static int ToInt32(this decimal num)
        {
            return (int)Math.Floor(num);
        }

        /// <summary>
        /// 字符串转long类型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultResult">转换失败的默认值</param>
        /// <returns></returns>
        public static long ToLong(this string str, long defaultResult)
        {
            if (!Int64.TryParse(str, out var result))
            {
                result = defaultResult;
            }
            return result;
        }

        #endregion 
    }
}
