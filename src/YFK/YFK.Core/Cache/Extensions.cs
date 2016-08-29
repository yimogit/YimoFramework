using System;

namespace YFK.Core.Cache
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class CacheExtensions
    {
        private static readonly object SyncObject = new object();

        /// <summary>
        /// 取缓存对象(如果缓存中不存在该项就设为缓存,默认缓存时间60分钟)
        /// </summary>
        /// <typeparam name="T">obj</typeparam>
        /// <param name="cacheManager">cacheManager</param>
        /// <param name="key">key</param>
        /// <param name="acquire">acquire</param>
        /// <returns></returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }

        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            lock (SyncObject)
            {
                if (cacheManager.IsSet(key))
                {
                    return cacheManager.Get<T>(key);
                }

                var result = acquire();
                if (cacheTime > 0)
                    cacheManager.Set(key, result, cacheTime);
                return result;
            }
        }
    }
}
