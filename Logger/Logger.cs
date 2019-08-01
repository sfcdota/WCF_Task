using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace LoggerNamespace
{
    /// <summary>
    /// Фабричный логгер, реализующий каждый из поддерживаемых типов логгеров, из enum
    /// </summary>
    public sealed class Logger
    {
        private readonly Dictionary<LoggersEnum, LoggerFactory> _Factories;
        public Logger()
        {
            _Factories = new Dictionary<LoggersEnum, LoggerFactory>
            {
                { LoggersEnum.log4net, new Log4netLoggerFactory() }
            };

        }
        /// <summary>
        /// Создание интерфейса, реализующего поддерживание доступных типов логгеров
        /// </summary>
        /// <param name="loggersEnum"></param>
        /// <returns></returns>
        public ILogger CreateLogger(LoggersEnum loggersEnum)
        {
            return _Factories[loggersEnum].Create();
        }
    }
}
