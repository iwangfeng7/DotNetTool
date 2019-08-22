using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 二进制帮助类
    /// </summary>
    public static class ByteHelper
    {
        // <summary>
        /// 合并字节数组
        /// </summary>
        public static byte[] Merge(this byte[] groupA, byte[] groupB)
        {
            //处理null
            if (groupA == null)
            {
                return groupB;
            }

            if (groupB == null)
            {
                return groupA;
            }

            var newGroup = new byte[groupA.Length + groupB.Length];

            Array.Copy(groupA, 0, newGroup, 0, groupA.Length);
            Array.Copy(groupB, 0, newGroup, groupA.Length, groupB.Length);

            return newGroup;
        }

        /// <summary>
        /// 将字节数组转为字符串
        /// </summary>
        public static string ToStr(this byte[] byteGroup)
        {
            return Encoding.UTF8.GetString(byteGroup);
        }

        /// <summary>
        /// 转为字节数组
        /// </summary>
        public static byte[] ToByteGroup(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// 转换为Json字节数组
        /// </summary>
        public static byte[] ToJsonByte(this object obj)
        {
            var json = obj.ToJson();

            var byteGroup = ToByteGroup(json);

            return byteGroup;
        }

        /// <summary>
        /// 将Json字节数组转换为对象
        /// </summary>
        public static object FromJsonByte(this byte[] byteGroup,Type type)
        {
            var json = ToStr(byteGroup);
            var obj = json.FromJson(type);

            return obj;
        }

        /// <summary>
        /// 将Json字节数组转换为对象
        /// </summary>
        public static T FromJsonByte<T>(this byte[] byteGroup)
        {
            return (T)FromJsonByte(byteGroup, typeof(T));
        }
    }
}
