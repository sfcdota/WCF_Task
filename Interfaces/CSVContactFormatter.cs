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

        public string Format(Contact contact)
        {
            return contact.Surname + ';'
                + contact.Name + ';'
                + contact.Patronymic + ';'
                + contact.TaxpayerIdentificationNumber + ';'
                + contact.Position + ';'
                + contact.Sex + ';'
                + contact.BirthDate;
        }
    }
}
