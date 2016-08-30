using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YFK.Core.Logger
{
    public class Log4netLogger:ILogger
    {
        log4net.ILog logger;
        public Log4netLogger()
        {
            //启动log4net
            log4net.Config.XmlConfigurator.Configure();
            logger = log4net.LogManager.GetLogger("application");
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
