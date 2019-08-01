using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace LoggerNamespace
{
    public sealed class Log4netLogger : ILogger
    {
        private static readonly log4net.ILog _Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //почему юзается рефлексия на currentmethod

        public void Error(string error)
        {
            _Log.Error(error);
        }

        public void Info(string info)
        {
            _Log.Info(info);
        }
    }
}
