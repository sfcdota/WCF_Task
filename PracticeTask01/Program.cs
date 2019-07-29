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
            DataStructuresTaskAndCheckAttribute();
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
        }
    }
}
/* сделать так, чтобы переход с одного логгера на другой был минимален по изменениям в коде
 */