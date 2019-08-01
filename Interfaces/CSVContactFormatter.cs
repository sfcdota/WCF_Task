using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ContactDLL
{
    /// <summary>
    /// Форматировщик типа CSV для IEnumerable коллекции контактов
    /// </summary>
    public sealed class CSVContactFormatter : IFormatter
    {
        /// <summary>
        /// Функция форматирования коллекции в CSV формат
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="dataFormat"></param>
        /// <returns></returns>
        public string Format(IEnumerable<Contact> contacts, string dataFormat)
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
                output.Append(contact.BirthDate.ToString(dataFormat));
                output.Append(Environment.NewLine);
            }
            return output.ToString();
        }
    }
}
