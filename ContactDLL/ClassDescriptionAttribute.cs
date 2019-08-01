using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    /// <summary>
    /// класс атрибута, предназначенного для описания других классов
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ClassDescriptionAttribute : System.Attribute
    {
        public string Description { get; set; }
    }
}
