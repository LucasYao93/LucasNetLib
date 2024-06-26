﻿using Microsoft.Extensions.Caching.Memory;

namespace LucasNetLib.Fundamental.Cache
{
    public class SimpleMemoryCache<TItem>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        public TItem GetOrCreate(object key, Func<TItem> createItem)
        {
            TItem cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))
            // Look for cache key.
            {
                // Key not in cache, so get data.
                cacheEntry = createItem();
                // Save data in cache.
                _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }
    }
}
