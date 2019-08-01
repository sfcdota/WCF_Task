using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace LoggerNamespace
{
    public class Logger
    {
        private readonly Dictionary<LoggersEnum, LoggerFactory> _Factories;
        public Logger()
        {
            _Factories = new Dictionary<LoggersEnum, LoggerFactory>
            {
                { LoggersEnum.log4net, new Log4netLoggerFactory() }
            };

        }

        public ILogger CreateLogger(LoggersEnum loggersEnum)
        {
            return _Factories[loggersEnum].Create();
        }
    }
}
