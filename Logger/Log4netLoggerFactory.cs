using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerNamespace
{
    public class Log4netLoggerFactory : LoggerFactory
    {
        public override ILogger Create()
        {
            return new Log4netLogger();
        }
    }
}
