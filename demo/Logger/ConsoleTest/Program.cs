using Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //若提示log4net.config找不到，需将其属性改始终复制
            ILogger logger = new Log4netLogger();
            WriteTestLog(logger);
            logger = new FileLogger("Logs\\FileLogs\\");//bin下。
            WriteTestLog(logger);
            logger = new NLogger();
            WriteTestLog(logger);
        }
        static void WriteTestLog(ILogger logger)
        {
            logger.Info("输出信息");
            logger.Debug("测试信息");
            logger.Warn("警告信息");
            logger.Error(new Exception("错误信息"));
        }
    }
}
