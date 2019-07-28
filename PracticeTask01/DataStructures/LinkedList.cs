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
        public static void LinkedListBypass(LinkedList<Contact> contacts)
        {
            Console.WriteLine("Обход связного листа");
            foreach (var contact in contacts)
                Console.WriteLine(contact);
        }


        public static bool LinkedListContainsElement(LinkedList<Contact> contacts, Contact contact)
        {
            return contacts.Contains(contact);
        }

        public static void LinkedListDeleteElement(LinkedList<Contact> contacts, Contact contact)
        {
            Console.WriteLine("Deleting element \n {0} \n from {1}", contact.ToString(), contacts.GetType().Name);
            if (LinkedListContainsElement(contacts, contact))
                contacts.Remove(contact);
            else
                Console.WriteLine("Delete did not complete. Element was not in {0}", contacts.GetType().Name);
        }
    
        public static LinkedList<Contact> CreateLinkedListOfContactsFromSource(ArrayList source)
        {
            LinkedList<Contact> contactsLinkedList = new LinkedList<Contact>();
            foreach (object a in source)
            {
                contactsLinkedList.AddLast(a as Contact);
            }
            return contactsLinkedList;
        }
    }
}
