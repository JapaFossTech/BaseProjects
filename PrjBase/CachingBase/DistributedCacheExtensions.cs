using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrjBase.CachingBase;

public static class DistributedCacheExtensions
{
    public static bool TryGetValue<T>(
        this IDistributedCache cache,
        string key,
        out T? value)
    {
        value = default;
        byte[]? val = cache.Get(key);
        if (val == null) return false;
        value = JsonSerializer.Deserialize<T>(val);
        return true;
    }

    public static void Set<T>(
        this IDistributedCache cache,
        string key,
        T value,
        TimeSpan absoluteExpirationRelativeToNow)
    {
        byte[]? bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(
            value
            , options: new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            }
            ));
        cache.Set(key, bytes, new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow
        });
    }
}
//jsonOptions =>
//        jsonOptions.JsonSerializerOptions.ReferenceHandler =
//            ReferenceHandler.IgnoreCycles