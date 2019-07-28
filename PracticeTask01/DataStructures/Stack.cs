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
        public static void StackBypass(Stack<Contact> contacts)
        {
            Console.WriteLine("Обход стека");
            foreach (var contact in contacts)
                Console.WriteLine(contact);
        }

        public static bool StackContainsElement(Stack<Contact> contacts, Contact contact)
        {
            return contacts.Contains(contact);
        }

        public static void StackDeleteElement(Stack<Contact> contacts, Contact contact)
        {
            Console.WriteLine("Deleting element \n {0} \n from {1}", contact.ToString(), contacts.GetType().Name);
            if (StackContainsElement(contacts, contact))
            {
                Stack<Contact> tempStack = new Stack<Contact>();
                Contact temp = new Contact();
                while (!contacts.Peek().Equals(contact))
                    tempStack.Push(contacts.Pop());
                contacts.Pop();
                while(tempStack.Count > 0)
                    contacts.Push(tempStack.Pop());
            }
            else
                Console.WriteLine("Delete did not complete. Element was not in {0}", contacts.GetType().Name);
        }

        public static Stack<Contact> CreateStackOfContactsFromSource(ArrayList source)
        {
            Stack<Contact> contactsStack = new Stack<Contact>();
            foreach (object a in source)
            {
                contactsStack.Push(a as Contact);
            }
            return contactsStack;
        }
    }
}
