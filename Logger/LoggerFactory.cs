using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerNamespace
{
    public abstract class LoggerFactory
    {
        public abstract ILogger Create();
    }
}
