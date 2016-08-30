using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebConfiguration.Configuration
{
    public class ConnectionElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return this["name"].ToString();
            }
        }

        [ConfigurationProperty("connectionString", IsRequired = true, IsKey = false)]
        public string ConnectionString
        {
            get
            {
                return (string)this["connectionString"];
            }
        }
    }
}
