using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ContactDLL;
using System.IO;

namespace PracticeTask01
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var sourceArray = CreateArrayListOfContacts();
            var contactsList = CreateListOfContactsFromSource(sourceArray);
            string path = Path.Combine(Environment.CurrentDirectory, "SavedContacts");
            //var formatterfactory = new Formatter().CreateFormatter(Extensions.CSV, contactsList);
            //formatterfactory.Format(contactsList);
            using (ContactFileSaver contactFileSaver = new ContactFileSaver())
            {
                contactFileSaver.Save(path, contactsList);
            }
            Console.ReadKey();
            // Environment.NewLine
            /*
             * закомментировать публичные методы
             * Environment.NewLine
             * saver.Save(path, text);
             * FormattedContact formattedContact = new FormattedContact(contact);
            */
        }
    }
}
