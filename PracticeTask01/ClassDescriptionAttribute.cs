﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask01
{
    [AttributeUsage(AttributeTargets.Class)]
    class ClassDescriptionAttribute : System.Attribute
    {
        public string Description { get; set; }
    }
}
