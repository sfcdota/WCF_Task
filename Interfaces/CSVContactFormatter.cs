using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    public class CSVContactFormatter: IFormatter
    {
        /* private readonly Contact _Contact;
         public CSVContactFormatter(Contact contact)
         {
             _Contact = contact;
         }
         */


        public string Format(IEnumerable<Contact> contacts)
        {
            StringBuilder output = new StringBuilder();
            foreach (Contact contact in contacts)
            {
                output.Append(contact.Surname);
                output.Append(contact.Name);
                output.Append(contact.Patronymic);
                output.Append(contact.TaxpayerIdentificationNumber);
                output.Append(contact.Position);
                output.Append(contact.Sex);
                output.Append(contact.BirthDate);

            }
            return output.ToString();
        }
    }
}
