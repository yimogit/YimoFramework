using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFK.Core.Configuration
{
    public partial class ConnectionsCollections
    {
        public string DefaultConnectionString
        {
            get
            {
                return this["DefaultConnectionString"].ConnectionString;
            }
        }
        public string RedisConfigString
        {
            get
            {
                return this["RedisConfigString"].ConnectionString;
            }
        }
    }
}
