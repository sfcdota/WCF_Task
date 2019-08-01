using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace LoggerNamespace
{
    /// <summary>
    /// Логгер log4net, реализующий интерфейс фабричного логгера
    /// </summary>
    public sealed class Log4netLogger : ILogger
    {
        private static readonly log4net.ILog _Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        log4net.ILog _Logsdf = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //почему юзается рефлексия на currentmethod
        /// <summary>
        /// Запись типа Error в лог
        /// </summary>
        /// <param name="error"></param>
        public void Error(string error)
        {
            _Log.Error(error);
        }
        /// <summary>
        /// Запись типа Info в лог
        /// </summary>
        /// <param name="info"></param>
        public void Info(string info)
        {
            _Log.Info(info);
        }
    }
}
