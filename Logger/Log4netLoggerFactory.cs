using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerNamespace
{
    /// <summary>
    /// Фабричный класс log4net логгера
    /// </summary>
    public sealed class Log4netLoggerFactory : LoggerFactory
    {
        public override ILogger Create()
        {
            return new Log4netLogger();
        }
    }
}
