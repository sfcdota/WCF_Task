using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ContactDLL
{
    public class Formatter
    {
        private readonly Dictionary<Extensions, ContactFormatterFactory> _factories;
        public Formatter()
        {
            
            _factories = new Dictionary<Extensions, ContactFormatterFactory>
            {
                { Extensions.CSV, new CSVContactFormatterFactory() },
                { Extensions.TXT, new TXTContactFormatterFactory() },
                { Extensions.XML, new XMLContactFormatterFactory() },
            };
            /*
            foreach (Extensions extensions in Enum.GetValues(typeof(Extensions)))
            {
                var factory = (ContactFormatterFactory)Activator.CreateInstance(Type.GetType("FactoryMethod." + Enum.GetName(typeof(Extensions), extensions) + "Factory"));
                _factories.Add(extensions, factory);
            }
            */
        }

        //creating FormatterFactyory interface
        public IFormatter CreateFormatter(Extensions extensions, IEnumerable<Contact> contacts)
        {
            return _factories[extensions].Create(contacts);
        }
    }
}
