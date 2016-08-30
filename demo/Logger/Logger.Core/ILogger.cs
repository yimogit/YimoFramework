using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core
{
    public interface ILogger
    {
        void Info(string log);
        void Debug(string log);
        void Warn(string log);
        void Error(Exception ex);
    }
}
