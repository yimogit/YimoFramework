using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFK.Core.Configuration
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
        /// <summary>
        /// 日志保存路径 末尾带/
        /// </summary>
        /// <remarks>
        /// \文件夹\ 盘符:\文件夹\
        /// </remarks>
        public string LogPath
        {
            get
            {
                return this["logPath"].Value;
            }
        }
    }
}
