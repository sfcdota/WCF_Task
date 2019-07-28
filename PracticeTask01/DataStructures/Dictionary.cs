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
        public static void DictionaryBypass(Dictionary<int, Contact> contacts)
        {
            Console.WriteLine("Обход словаря");
            foreach (KeyValuePair<int, Contact> contact in contacts)
                Console.WriteLine(contact.Value);
        }

        public static bool DictionaryContainsElement(Dictionary<int, Contact> contacts, Contact contact)
        {
            return contacts.ContainsValue(contact);
        }

        public static void DictionaryDeleteElement(Dictionary<int, Contact> contacts, Contact contact)
        {
            Console.WriteLine("Deleting element \n {0} \n from {1}", contact.ToString(), contacts.GetType().Name);
            if (DictionaryContainsElement(contacts, contact))
                foreach (var dictionaryElement in contacts)
                    if (dictionaryElement.Value.Equals(contact))
                    {
                        contacts.Remove(dictionaryElement.Key);
                        break;
                    }
            else
                Console.WriteLine("Delete did not complete. Element was not in {0}", contacts.GetType().Name);
        }

        public static Dictionary<int, Contact> CreateDictionaryOfContactsFromSource(ArrayList source)
        {
            Dictionary<int, Contact> contactsDictionary = new Dictionary<int, Contact>();
            int i = 1;
            foreach (object a in source)
            {
                contactsDictionary.Add(i++, a as Contact);
            }
            return contactsDictionary;
        }
    }
}
