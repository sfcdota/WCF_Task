using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ContactDLL
{
    public class XMLContactFormatter: IFormatter
    {
        /*
        private readonly Contact _Contact;
        public XMLContactFormatter(Contact contact)
        {
            _Contact = contact;
        }
        */

        public string Format(IEnumerable<Contact> contacts)
        {
            foreach(Contact contact in contacts)
            {
                
            }
            return string.Empty;
        }
    }
}
