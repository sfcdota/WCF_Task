using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    /// <summary>
    /// Форматировщик типа TXT для IEnumerable коллекции контактов
    /// </summary>
    public sealed class TXTContactFormatter : IFormatter
    {
        /// <summary>
        /// Функция форматирования коллекции в TXT формат
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="dataFormat"></param>
        /// <returns></returns>
        public string Format(IEnumerable<Contact> contacts, string dataFormat)
        {
            StringBuilder output = new StringBuilder();
            foreach (Contact contact in contacts)
            {
                output.Append(contact.ToString(dataFormat));
                output.Append(Environment.NewLine);
            }
            return output.ToString();
        }
    }
}
