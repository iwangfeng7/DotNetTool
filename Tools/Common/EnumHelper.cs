using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class EnumHelper
    {
        private static readonly ConcurrentDictionary<Type, Dictionary<int, string>> EnumNameValueDict = new ConcurrentDictionary<Type, Dictionary<int, string>>();
        private static readonly ConcurrentDictionary<Type, Dictionary<string, int>> EnumValueNameDict = new ConcurrentDictionary<Type, Dictionary<string, int>>();
        private static ConcurrentDictionary<string, Type> _enumTypeDict;

        /// <summary>
        /// 获取枚举对象Key与显示名称的字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<int, string> Enum2Dictionary(this Type enumType)
        {
            if (!enumType.IsEnum) throw new Exception("给定类型不是枚举类型");
            Dictionary<int, string> names = EnumNameValueDict.ContainsKey(enumType) ? EnumNameValueDict[enumType] : new Dictionary<int, string>();
            if (names.Count == 0)
            {
                names = GetDictionaryItem(enumType);
                EnumNameValueDict[enumType] = names;
            }
            return names;
        }

        private static Dictionary<int, string> GetDictionaryItem(Type enumType)
        {
            FieldInfo[] enumItems = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            Dictionary<int, string> names = new Dictionary<int, string>(enumItems.Length);
            foreach (var enumItem in enumItems)
            {
                int intValue = (int)enumItem.GetValue(enumType);
                names[intValue] = enumItem.Name;
            }
            return names;
        }
        /// <summary>
        /// 获取枚举对象显示名称与Key的字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<string, int> EnumValue2Dictionary(this Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new Exception("给定类型不是枚举类型");
            }
            Dictionary<string, int> values = EnumValueNameDict.ContainsKey(enumType) ? EnumValueNameDict[enumType] : new Dictionary<string, int>();
            if (values.Count == 0)
            {
                values = GetValueNameItems(enumType);
                EnumValueNameDict[enumType] = values;
            }
            return values;
        }

        private static Dictionary<string, int> GetValueNameItems(Type enumType)
        {
            FieldInfo[] enumItems = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            Dictionary<string, int> values = new Dictionary<string, int>(enumItems.Length);
            foreach (var enumItem in enumItems)
            {
                values[enumItem.Name] = (int)enumItem.GetValue(enumType);
            }
            return values;
        }

        /// <summary>
        /// 获取枚举对象的值
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="name"></param>
        /// <returns>枚举对象值,如果不存在返回null</returns>
        public static int? GetEnumValue(this Type enumType, string name)
        {
            if (!enumType.IsEnum) throw new Exception("给定类型不是枚举类型");
            Dictionary<string, int> enumDict = GetValueNameItems(enumType);
            if (enumDict.ContainsKey(name))
            {
                return enumDict[name];
            }
            return null;
        }
        /// <summary>
        /// 获取枚举类型
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type GetEnumType(Assembly assembly, string typeName)
        {
            _enumTypeDict = _enumTypeDict ?? LoadEnumTypeDict(assembly);
            return _enumTypeDict.ContainsKey(typeName) ? _enumTypeDict[typeName] : null;
        }
        private static ConcurrentDictionary<string, Type> LoadEnumTypeDict(Assembly assembly)
        {
            Type[] typeArray = assembly.GetTypes();
            Dictionary<string, Type> dict = typeArray.Where(x => x.IsEnum).ToDictionary(x => x.Name, x => x);
            return new ConcurrentDictionary<string, Type>(dict);
        }
        /// <summary>
        /// 获取枚举描述和值的字典集合
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetEnumDescriptionAndValueDict(this Type enumType)
        {
            Dictionary<string, int> dicResult = new Dictionary<string, int>();
            foreach (var e in Enum.GetValues(enumType))
            {
                dicResult.Add(GetEnumDescription(e as Enum), (int)e);
            }
            return dicResult;
        }
        /// <summary>
        /// 根据枚举成员获取Description
        /// </summary>
        /// <param name="en">枚举成员</param>
        /// <returns>Description</returns>
        public static string GetEnumDescription(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memberInfos = type.GetMember(en.ToString());
            if (memberInfos.Any())
            {
                DescriptionAttribute[] attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];//获取描述特性
                if (attrs != null && attrs.Length > 0)
                {
                    return attrs[0].Description;
                }
            }
            return en.ToString();
        }
        /// <summary>
        /// 根据枚举值得到响应枚举定义字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string ToEnumString(this int value, Type enumType)
        {
            NameValueCollection nvc = GetEnumStringFromEnumValue(enumType);
            return nvc[value.ToString()];
        }
        /// <summary>
        /// 根据枚举类型得到其所有值与枚举字符串的集合
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static NameValueCollection GetEnumStringFromEnumValue(Type enumType)
        {
            NameValueCollection nvc = new NameValueCollection();
            FieldInfo[] fields = enumType.GetFields();
            foreach (var field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    var strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    nvc.Add(strValue, field.Name);
                }
            }
            return nvc;
        }
    }
}
