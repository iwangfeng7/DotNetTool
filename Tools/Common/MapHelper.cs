using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Common;
using Newtonsoft.Json;

namespace Extensions
{
    public static class MapExtension
    {
        /// <summary>
        /// 映射到目标类型(浅克隆)
        /// </summary>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源</param>
        /// <returns>目标类型</returns>
        public static TDestination MapTO<TDestination>(this object source) where TDestination : new()
        {
            TDestination dest = new TDestination();
            dest.GetType().GetProperties().ForEach(x =>
            {
                x.SetValue(dest, source.GetType().GetProperty(x.Name)?.GetValue(source));
            });
            return dest;
        }
        /// <summary>
        /// 映射到目标类型(浅克隆)
        /// </summary>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源</param>
        /// <returns>目标类型</returns>
        public static async Task<TDestination> MapToAsync<TDestination>(this object source) where TDestination : new()
        {
            return await Task.Run(() =>
           {
               TDestination dest = new TDestination();
               dest.GetType().GetProperties().ForEach(x =>
               {
                   x.SetValue(dest, source.GetType().GetProperty(x.Name)?.GetValue(source));
               });
               return dest;
           });
        }
        /// <summary>
        /// 映射到目标类型(深克隆)
        /// </summary>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源</param>
        /// <returns></returns>
        public static async Task<TDestination> Map<TDestination>(this object source) where TDestination : new()
        {
            return JsonConvert.DeserializeObject<TDestination>(JsonConvert.SerializeObject(source));
        }
        /// <summary>
        /// 映射到目标类型(深克隆)
        /// </summary>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源</param>
        /// <returns></returns>
        public static async Task<TDestination> MapAsync<TDestination>(this object source) where TDestination : new()
        {
            return await Task.Run(() =>
                JsonConvert.DeserializeObject<TDestination>(JsonConvert.SerializeObject(source))
            );
        }
        /// <summary>
        /// 复制到一个现有对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源对象</param>
        /// <param name="dest">目标对象</param>
        /// <returns></returns>
        public static T CopyTo<T>(this T source, T dest) where T : new()
        {
            dest.GetType().GetProperties().ForEach(x =>
            {
                x.SetValue(dest, source.GetType().GetProperty(x.Name)?.GetValue(source));
            });
            return dest;
        }
        /// <summary>
        /// 复制一个新的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<T> CopyAsync<T>(this T source) where T : new()
        {
            return await Task.Run(() =>
            {
                T dest = new T();
                dest.GetType().GetProperties().ForEach(x =>
                {
                    x.SetValue(dest, source.GetType().GetProperty(x.Name)?.GetValue(source));
                });
                return dest;
            });
        }
        /// <summary>
        /// 映射到目标类型的集合
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型集合</returns>
        public static IEnumerable<TDestination> ToList<TDestination>(this object[] source) where TDestination : new()
        {
            foreach (var o in source)
            {
                var dest = new TDestination();
                dest.GetType().GetProperties().ForEach(y =>
                    {
                        y.SetValue(dest, source.GetType().GetProperty(y.Name).GetValue(o));
                    });
                yield return dest;
            }
        }
        /// <summary>
        /// 映射到目标类型的集合
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型集合</returns>
        public static async Task<IEnumerable<TDestination>> ToListAsync<TDestination>(this object[] source) where TDestination : new()
        {
            return await Task.Run(() =>
            {
                IList<TDestination> list = new List<TDestination>();
                foreach (var o in source)
                {
                    var dest = new TDestination();
                    dest.GetType().GetProperties().ForEach(x =>
                    {
                        x.SetValue(dest, source.GetType().GetProperty(x.Name)?.GetValue(o));
                    });
                    list.Add(dest);
                }
                return list;
            });
        }
        /// <summary>
        /// 映射到目标类型的集合
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型集合</returns>
        public static IEnumerable<TDestination> ToList<TDestination>(this IEnumerable<dynamic> source) where TDestination : new()
        {
            foreach (var o in source)
            {
                var dest = new TDestination();
                dest.GetType().GetProperties().ForEach(x =>
                {
                    x.SetValue(dest, source.GetType().GetProperty(x.Name)?.GetValue(o));
                });
                yield return dest;
            }
        }
        /// <summary>
        /// 映射到目标类型的集合
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型集合</returns>
        public static async Task<IEnumerable<TDestination>> ToListAsync<TDestination>(this IEnumerable<dynamic> source) where TDestination : new()
        {
            return await Task.Run(() =>
            {
                IList<TDestination> list = new List<TDestination>();
                foreach (var o in source)
                {
                    var dest = new TDestination();
                    dest.GetType().GetProperties().ForEach(x =>
                    {
                        x.SetValue(dest, source.GetType().GetProperty(x.Name)?.GetValue(o));
                    });
                    list.Add(dest);
                }
                return list;
            });
        }
        /// <summary>
        /// 转换成json字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToJsonString(this object source)
        {
            return JsonConvert.SerializeObject(source, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
        /// <summary>
        /// 转换为json字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<string> ToJsonStringAsync(this object source)
        {
            return await Task.Run(() => JsonConvert.SerializeObject(source));
        }

    }
}
