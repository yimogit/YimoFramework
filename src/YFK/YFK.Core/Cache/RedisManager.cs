using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Caching;
using System.Web.Compilation;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace YFK.Core.Cache
{
    public class RedisManager : ICacheManager
    {
        public T Get<T>(string key)
        {
            var db = RedisConnection.Connection.GetDatabase();
            var json = db.StringGet(key);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Set(string key, object data, int cacheTime)
        {
            var json = JsonConvert.SerializeObject(data);
            var db = RedisConnection.Connection.GetDatabase();
            db.StringSet(key, json, TimeSpan.FromMinutes(cacheTime));
        }

        public bool IsSet(string key)
        {
            var db = RedisConnection.Connection.GetDatabase();
            return db.KeyExists(key);
        }

        public void Remove(string key)
        {
            var db = RedisConnection.Connection.GetDatabase();
            db.KeyDelete(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var keys = SearchKeys(pattern+"*");

            var db = RedisConnection.Connection.GetDatabase();
            foreach (var s in keys)
            {
                db.KeyDelete(s);
            }
        }

        public void Clear()
        {
        }

        private IEnumerable<string> SearchKeys(string pattern)
        {
            var db = RedisConnection.Connection.GetDatabase();
            var keys = new HashSet<RedisKey>();

            var endPoints = db.Multiplexer.GetEndPoints();

            foreach (var endpoint in endPoints)
            {
                var dbKeys = db.Multiplexer.GetServer(endpoint).Keys(db.Database, pattern);

                foreach (var dbKey in dbKeys)
                {
                    if (!keys.Contains(dbKey))
                    {
                        keys.Add(dbKey);
                    }
                }
            }

            return keys.Select(x => (string)x);
        }
    }
}
