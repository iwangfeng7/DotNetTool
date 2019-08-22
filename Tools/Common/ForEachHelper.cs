using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ForEachHelper
    {
        #region SyncForEach

        #region ForEach无返回值
        /// <summary>
        /// 遍历数组
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">处理方法</param>
        public static void ForEach(this object[] objs, Action<object> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }
        /// <summary>
        /// 遍历IEnumerable
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">处理方法</param>
        public static void ForEach(this IEnumerable<dynamic> objs, Action<object> action)
        {
            foreach (var o in objs)
            {
                action(0);
            }
        }
        /// <summary>
        /// 遍历集合
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">处理方法</param>
        public static void ForEach(this IList<dynamic> objs, Action<object> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }
        /// <summary>
        /// 遍历数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action">处理方法</param>
        public static void ForEach<T>(this T[] objs, Action<T> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }
        /// <summary>
        /// 遍历IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action">处理方法</param>
        public static void ForEach<T>(this IEnumerable<T> objs, Action<T> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }
        /// <summary>
        /// 遍历List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action">处理方法</param>
        public static void ForEach<T>(this IList<T> objs, Action<T> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }
        #endregion

        #region ForEach有返回值
        /// <summary>
        /// 遍历数组并返回一个新的List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this object[] objs, Func<object, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }
        /// <summary>
        /// 遍历IEnumerable并返回一个新的List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> Foreach<T>(this IEnumerable<dynamic> objs, Func<object, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }
        /// <summary>
        /// 遍历List并返回一个新List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IList<dynamic> objs, Func<object, T> action)
        {
            foreach (T o in objs)
            {
                yield return action(o);
            }
        }
        /// <summary>
        /// 遍历数组并返回一个新的List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this T[] objs, Func<T, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }
        /// <summary>
        /// 遍历IEnumerable并返回一个新的List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> objs, Func<T, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }
        /// <summary>
        /// 遍历List并返回一个新的List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IList<T> objs, Func<T, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }

        #endregion

        #endregion

        #region AsyncForEach
        /// <summary>
        /// 遍历数组
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action"></param>
        public static async void ForEachAsync(this object[] objs, Action<object> action)
        {
            await Task.Run(() =>
            {
                Parallel.ForEach(objs, action);
            });
        }
        /// <summary>
        /// 遍历数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action"></param>
        public static async void ForEachAsync<T>(this T[] objs, Action<T> action)
        {
            await Task.Run(() =>
            {
                Parallel.ForEach(objs, action);
            });
        }
        /// <summary>
        /// 遍历IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action"></param>
        public static async void ForEachAsync<T>(this IEnumerable<T> objs, Action<T> action)
        {
            await Task.Run(() =>
            {
                Parallel.ForEach(objs, action);
            });
        }
        /// <summary>
        /// 遍历List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <param name="action"></param>
        public static async void ForEachAsync<T>(this IList<T> objs, Action<T> action)
        {
            await Task.Run(() =>
            {
                Parallel.ForEach(objs, action);
            });
        }
        #endregion

    }
}
