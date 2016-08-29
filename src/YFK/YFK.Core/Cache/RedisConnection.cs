using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Caching;
using System.Web.Compilation;
using StackExchange.Redis;

namespace YFK.Core.Cache
{
    public static class RedisConnection
    {
        private static readonly string ConnectionString = YFK.Core.Configuration.YFKConfig.Instance.Connections.RedisConfigString;

        private static readonly Lazy<ConnectionMultiplexer> Conn = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(ConnectionString));

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return Conn.Value;
            }
        }
    }
}
