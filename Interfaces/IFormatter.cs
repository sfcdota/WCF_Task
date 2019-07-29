using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    public interface IFormatter
    {
        string Format(IEnumerable<Contact> contacts, string dataFormat);
    }
}