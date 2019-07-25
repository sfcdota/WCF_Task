using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    public abstract class Person
    {
        public abstract string _Surname { get; set; }
        public abstract string _Name { get; set; }
        public abstract string _Patronymic { get; set; }
        public abstract string _Sex { get; set; }
    }
}
