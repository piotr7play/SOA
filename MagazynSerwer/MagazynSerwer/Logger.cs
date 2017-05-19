using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazynSerwer
{
    public class Logger : ILogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Object));

        public void Write(string msg, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.FATAL:
                    log.Fatal(msg);
                    break;
                case LogLevel.ERROR:
                    log.Error(msg);
                    break;
                case LogLevel.WARN:
                    log.Warn(msg);
                    break;
                case LogLevel.INFO:
                    log.Info(msg);
                    break;
                case LogLevel.DEBUG:
                    log.Debug(msg);
                    break;
            }
        }
    }
}
