using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassDescriptionAttribute : System.Attribute
    {
        public string Description { get; set; }
    }
}
