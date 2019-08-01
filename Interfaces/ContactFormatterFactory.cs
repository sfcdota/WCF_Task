using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    /// <summary>
    /// Фабрика для форматировщиков IEnumerable коллекции контактов
    /// </summary>
    public abstract class ContactFormatterFactory
    {
        public abstract IFormatter Create(IEnumerable<Contact> contacts);
    }
}
