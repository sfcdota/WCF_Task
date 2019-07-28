using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    public class TXTContactFormatterFactory: ContactFormatterFactory
    {
        public override IFormatter Create(IEnumerable<Contact> contacts)
        {
            return new TXTContactFormatter();
        }
    }
}
