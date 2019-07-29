using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
                output.Append(";");
                output.Append(contact.Name);
                output.Append(";");
                output.Append(contact.Patronymic);
                output.Append(";");
                output.Append(contact.TaxpayerIdentificationNumber);
                output.Append(";");
                output.Append(contact.Position);
                output.Append(";");
                output.Append(contact.Sex);
                output.Append(";");
                output.Append(contact.TelephoneNumber);
                output.Append(";");
                output.Append(contact.BirthDate.ToString(ConfigurationManager.AppSettings["DataFormat"]));
                output.Append(Environment.NewLine);
            }
            return output.ToString();
        }
    }
}
