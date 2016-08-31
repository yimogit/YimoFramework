using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core
{
    public class NLogger : ILogger
    {
        NLog.ILogger logger;
        public NLogger()
        {
            logger = LogManager.GetLogger("Application");
        }
        public void Info(string log)
        {
            logger.Info(log);
        }

        public void Debug(string log)
        {
            logger.Debug(log);
        }
        public void Warn(string log)
        {
            logger.Warn(log);
        }

        public void Error(Exception ex)
        {
            StringBuilder errMsg = new StringBuilder();
            if (System.Web.HttpContext.Current != null)
            {
                errMsg.Append("请求地址：" + System.Web.HttpContext.Current.Request.Url.AbsoluteUri + "\r\n");
                errMsg.Append("请求IP：" + System.Web.HttpContext.Current.Request.UserHostAddress + "\r\n");
            }
            errMsg.Append("错误消息：" + ex.Message + "\r\n");
            errMsg.Append("错误对象：" + ex.Source + "\r\n");
            errMsg.Append("栈堆信息：" + ex.StackTrace + "\r\n");
            logger.Error(errMsg.ToString());
        }
    }
}
