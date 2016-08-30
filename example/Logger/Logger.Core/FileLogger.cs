using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core
{
    public class FileLogger : ILogger
    {
        private string LogPath { get; set; }
        public FileLogger(string path)
        {
            this.LogPath = path;
        }
        public void Info(string log)
        {
            WriteLog(LogLevel.Info, log);
        }

        public void Debug(string log)
        {
            WriteLog(LogLevel.Debug, log);
        }
        public void Warn(string log)
        {
            WriteLog(LogLevel.Warn, log);
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
            WriteLog(LogLevel.Error, errMsg.ToString());
        }
        private void WriteLog(LogLevel level, string log)
        {
            var path = string.Format(@"{0}{1}\{2}", this.LogPath, DateTime.Now.ToString("yyyy年MM月dd日"), level.ToString());
            if (path.Contains(":\\") == false)
            {
                if (System.Web.HttpContext.Current != null)
                    path = System.Web.HttpContext.Current.Server.MapPath(path);
                else
                    path = AppDomain.CurrentDomain.BaseDirectory + path;
            }
            var fileName = string.Format("{0}.txt", DateTime.Now.ToString("HH"));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.Append, FileAccess.Write,
                                                  FileShare.Write, 1024, FileOptions.Asynchronous))
            {
                log = string.Format("================记录时间：{0}================\r\n{1}\r\n",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), log);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(log + "\r\n");
                IAsyncResult writeResult = fs.BeginWrite(buffer, 0, buffer.Length,
                    (asyncResult) =>
                    {
                        var fStream = (FileStream)asyncResult.AsyncState;
                        fStream.EndWrite(asyncResult);
                    },
                    fs);
                fs.Close();
            }

        }
    }
}
