using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common
{
    /// <summary>
    /// Json帮助类
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 对象转换为Json
        /// </summary>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Json转换为对象
        /// </summary>
        public static object FromJson(this string str,Type type)
        {
            return JsonConvert.DeserializeObject(str, type);
        }

        /// <summary>
        /// Json转换为对象
        /// </summary>
        public static T FromJson<T>(this string str)
        {
            return (T)FromJson(str, typeof(T));
        }

        /// <summary>
        /// 克隆
        /// </summary>
        public static T Clone<T>(this T model)
        {
            var json = model.ToJson();

            var clone = json.FromJson<T>();

            return clone;
        }


        /// <summary>
        /// 获取字符串形式值
        /// </summary>
        public static string GetStr(this JToken token)
        {
            if(token is JProperty)
            {
                token = ((JProperty)token).Value;
            }

            return token.Type == JTokenType.Null ? null : token.ToString();
        }
    }
}
