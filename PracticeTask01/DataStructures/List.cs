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
        public static void ListBypass(List<Contact> contacts)
        {
            Console.WriteLine("Обход листа");
            foreach (var contact in contacts)
                Console.WriteLine(contact);
        }

        public static bool ListContainsElement(List<Contact> contacts, Contact contact)
        {
            return contacts.Contains(contact);
        }

        public static void ListDeleteElement(List<Contact> contacts, Contact contact)
        {
            Console.WriteLine("Deleting element \n {0} \n from {1}", contact.ToString(), contacts.GetType().Name);
            if (ListContainsElement(contacts, contact))
                contacts.Remove(contact);
            else
                Console.WriteLine("Delete did not complete. Element was not in {0}", contacts.GetType().Name);
        }

        public static List<Contact> CreateListOfContactsFromSource(ArrayList source)
        {
            List<Contact> contactsList = new List<Contact>();
            foreach(object a in source)
            {
                contactsList.Add(a as Contact);
            }
            return contactsList;
        }
    }
}
