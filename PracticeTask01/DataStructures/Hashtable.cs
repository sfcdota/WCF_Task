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
        public static void HashtableBypass(Hashtable contacts)
        {
            Console.WriteLine("Обход хэш-таблицы");
            foreach (DictionaryEntry contact in contacts)
                Console.WriteLine(contact.Value);
        }

        public static bool HashtableContainsElement(Hashtable hashtable, Contact contact)
        {
            return hashtable.ContainsValue(contact);
        }

        public static void HashtableDeleteElement(Hashtable hashtable, Contact contact)
        {
            Console.WriteLine("Deleting element \n {0} \n from {1}", contact.ToString(), hashtable.GetType().Name);
            if (HashtableContainsElement(hashtable, contact))
                foreach (DictionaryEntry hashtableElement in hashtable)
                {
                    if (hashtableElement.Value.Equals(contact))
                    {
                        hashtable.Remove(hashtableElement.Key);
                        break;
                    }
                }
            else
                Console.WriteLine("Delete did not complete. Element was not in {0}", hashtable.GetType().Name);
        }

        public static Hashtable CreateHashtableOfContactsFromSource(ArrayList source)
        {
            Hashtable contactsHashtable = new Hashtable();
            int i = 1;
            foreach (object a in source)
            {
                contactsHashtable.Add(i++, a as Contact);
            }
            return contactsHashtable;
        }
    }
}
