using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebConfiguration.Configuration
{
    public class YFKConfig:ConfigurationSection
    {
        private static YFKConfig _instance;
        private static object objLock=new object();
        public static YFKConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (objLock)
                    {
                        if (_instance == null)
                        {
                            _instance = (YFKConfig)ConfigurationManager.GetSection("YFKConfig");
                        }
                    }
                }
                return _instance;
            }
        }
        [ConfigurationProperty("connections")]
        public ConnectionsCollections Connections
        {
            get
            {
                return (ConnectionsCollections)base["connections"];
            }
        }
        /// <summary>
        /// 网站设置
        /// </summary>
        [ConfigurationProperty("webSetting")]
        public WebSettingCollections WebSetting {
            get
            {
                return (WebSettingCollections)base["webSetting"];
            }
        }

    }
}
