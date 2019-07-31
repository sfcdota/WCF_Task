using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace LoggerNamespace
{
    public class Log4netLogger : ILogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Error(string error)
        {
            log.Error(error);
        }

        public void Info(string info)
        {
            log.Info(info);
        }
    }
}
