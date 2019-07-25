using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    public class CSVContactFormatter: IFormatter
    {
        private readonly Contact _Contact;
        public CSVContactFormatter(Contact contact)
        {
            _Contact = contact;
        }

        public string Format()
        {
            return _Contact.Surname + ';'
                + _Contact.Name + ';'
                + _Contact.Patronymic + ';'
                + _Contact.TaxpayerIdentificationNumber + ';'
                + _Contact.Position + ';'
                + _Contact.Sex + ';'
                + _Contact.BirthDate;
        }
    }
}
