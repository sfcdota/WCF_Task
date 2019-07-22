using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask01
{
    [AttributeUsage(AttributeTargets.Property)]
    class MinimalBirthDateAttribute: System.Attribute
    {
        public DateTime MinimalDate { get; set; }
    }
}
