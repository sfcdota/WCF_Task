using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerNamespace
{
    /// <summary>
    /// Фабрика логгеров
    /// </summary>
    public abstract class LoggerFactory
    {
        public abstract ILogger Create();
    }
}
