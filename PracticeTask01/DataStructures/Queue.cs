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
        public static void QueueBypass(Queue<Contact> contacts)
        {
            Console.WriteLine("Обход очереди");
            foreach (var contact in contacts)
                Console.WriteLine(contact);
        }

        public static bool QueueContainsElement(Queue<Contact> contacts, Contact contact)
        {
            return contacts.Contains(contact);
        }

        public static void QueueDeleteElement(Queue<Contact> contacts, Contact contact)
        {
            Console.WriteLine("Deleting element \n {0} \n from {1}", contact.ToString(), contacts.GetType().Name);
            if (QueueContainsElement(contacts, contact))
            {
                Queue<Contact> newQueue = new Queue<Contact>();
                Contact temp = new Contact();
                bool deleted = false;
                while (contacts.Count > 0)
                    if (!deleted && contacts.Peek().Equals(contact))
                    {
                        deleted = !deleted;
                        contacts.Dequeue();
                    }
                    else
                        newQueue.Enqueue(contacts.Dequeue());
                contacts = newQueue;
            }
            else
                Console.WriteLine("Delete did not complete. Element was not in {0}", contacts.GetType().Name);
        }

        public static Queue<Contact> CreateQueueOfContactsFromSource(ArrayList source)
        {
            Queue<Contact> contactsQueue = new Queue<Contact>();
            foreach (object a in source)
            {
                contactsQueue.Enqueue(a as Contact);
            }
            return contactsQueue;
        }
    }
}
