using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    public class CSVContactFormatterFactory : ContactFormatterFactory
    {
        public override IFormatter Create(Contact contact) => new CSVContactFormatter(contact);
    }
}
