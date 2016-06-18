﻿using System;
using System.Runtime.Caching;

namespace ApiHackaton.Factory
{
    public class MemoryCacher
    {
        public static T GetValue<T>(string key)
        {
            var memoryCache = MemoryCache.Default;

            return (T)Convert.ChangeType(memoryCache.Get(key), typeof(T));
        }

        public static bool Add(string key, object value, DateTimeOffset? absExpiration)
        {
            var memoryCache = MemoryCache.Default;

            if (absExpiration != null)
                return memoryCache.Add(key, value, absExpiration.Value);

            var policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.NotRemovable
            };
            return memoryCache.Add(key, value, policy);
        }

        public static void Delete(string key)
        {
            var memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }

        public static bool CheckIfAlreadyExists<T>(string key)
        {
            return GetValue<T>(key) != null;
        }
    }
}