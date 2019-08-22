using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Md5帮助类
    /// </summary>
    public static class Md5Helper
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="byteGroup">二进制数据</param>
        public static string Md5(this byte[] byteGroup)
        {
            var sb = new StringBuilder();

            // 创建一个MD5对象
            var md5Hash = System.Security.Cryptography.MD5.Create();

            // 计算指定直接数据的哈希值
            byte[] data = md5Hash.ComputeHash(byteGroup);

            //将结果字节数组组成字符串返回
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            // 返回
            return sb.ToString();
        }
    }
}
