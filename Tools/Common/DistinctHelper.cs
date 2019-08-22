using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DistinctHelper
    {
        /// <summary>
        /// 字段去重
        /// </summary>
        /// <typeparam name="TSource">源</typeparam>
        /// <typeparam name="Tkey">字段(多个字段用元组)</typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, Tkey>(this IEnumerable<TSource> source, Func<TSource, Tkey> keySelector)
        {
            HashSet<Tkey> hash = new HashSet<Tkey>();
            return source.Where(x => hash.Add(keySelector(x)));
        }
    }
}
