using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    public class XMLContactFormatterFactory: ContactFormatterFactory
    {
        public override IFormatter Create(Contact contact) => new XMLContactFormatter(contact);
    }
}
