using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebConfiguration.Configuration
{
    public partial class WebSettingCollections
    {
        /// <summary>
        /// 主站点域名
        /// </summary>
        public string MainDomin
        {
            get
            {
                return this["mainDomin"].Value;
            }
        }
        /// <summary>
        /// 后台域名
        /// </summary>
        public string AdminDomin
        {
            get
            {
                return this["adminDomin"].Value;
            }
        }
    }
}
