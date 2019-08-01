using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace LoggerNamespace
{
    /// <summary>
    /// Интерфейс функционала логгера
    /// </summary>
    public interface ILogger
    {
        void Info(string info);
        void Error(string error);
    }
}
