using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    /// <summary>
    /// Интерфейс функционала форматировщика
    /// </summary>
    public interface IFormatter
    {
        string Format(IEnumerable<Contact> contacts, string dataFormat);
    }
}