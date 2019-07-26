using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    public abstract class Person
    {
        public abstract string Surname { get; set; }
        public abstract string Name { get; set; }
        public abstract string Patronymic { get; set; }
        public abstract string Sex { get; set; }
    }
}
