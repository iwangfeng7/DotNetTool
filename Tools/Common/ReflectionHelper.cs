using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ReflectionHelper
    {
        public static BindingFlags bfs = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        /// <summary>
        /// 设置字段
        /// </summary>
        /// <param name="obj">反射对象</param>
        /// <param name="name">字段名</param>
        /// <param name="value">值</param>
        public static void SetField(this object obj, string name, object value)
        {
            FieldInfo fi = obj.GetType().GetField(name, bfs);
            fi?.SetValue(obj, value);
        }
    }
}
