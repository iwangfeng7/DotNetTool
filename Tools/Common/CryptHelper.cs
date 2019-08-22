using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 加密解密算法帮助类
    /// </summary>
    public static class CryptHelper
    {
        /// <summary>
        /// 加密解密的密钥
        /// </summary>
        public static readonly string Key = "1dSD@!92";

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="str">原文</param>
        public static string DesEncrypt(string str)
        {
            //inputBytes
            var inputByteGroup = str.ToByteGroup();

            //keyBytes
            var keyByteGroup = Key.Substring(0, 8).ToByteGroup();
            var keyIv = keyByteGroup;
            var provider = new DESCryptoServiceProvider()
            {
                Key = keyByteGroup,
                IV = keyIv
            };

            //加密
            var mStream = new MemoryStream();
            var cStream = new CryptoStream(mStream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            cStream.Write(inputByteGroup, 0, inputByteGroup.Length);
            cStream.FlushFinalBlock();

            return Convert.ToBase64String(mStream.ToArray());
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="str">密文</param>
        public static string DesDecrypt(string str)
        {
            //inputBytes
            var inputByteGroup = Convert.FromBase64String(str);

            //keyBytes
            var keyByteGroup = Key.Substring(0, 8).ToByteGroup();
            var keyIv = keyByteGroup;
            var provider = new DESCryptoServiceProvider()
            {
                Key = keyByteGroup,
                IV = keyIv
            };

            //加密
            var mStream = new MemoryStream();
            var cStream = new CryptoStream(mStream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            cStream.Write(inputByteGroup, 0, inputByteGroup.Length);
            cStream.FlushFinalBlock();

            return mStream.ToArray().ToStr();
        }
    }
}
