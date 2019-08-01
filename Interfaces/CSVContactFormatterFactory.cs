using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    /// <summary>
    /// Фабричный класс CSV форматировщика
    /// </summary>
    public sealed class CSVContactFormatterFactory : ContactFormatterFactory
    {
        public override IFormatter Create(IEnumerable<Contact> contacts)
        {
            return new CSVContactFormatter();
        }
    }
}
