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
        //checking valid birthday
        public static bool ValidateBirthDate(Contact contact, int year, int month, int day)
        {
            DateTime temp = new DateTime(year, month, day);
            if (contact.BirthDate.Ticks > temp.Ticks)
                return true;
            else return false;
        }
        //checking valid birthday property with attribute
        public static void CheckBirthDateProperty()
        {
            Contact contact = new Contact() { BirthDate = DateTime.Now };
            Type type = typeof(Contact);
            PropertyInfo propertyInfo = type.GetProperty(nameof(Contact.BirthDate),
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            MinimalBirthDateAttribute attr = propertyInfo.GetCustomAttributes<MinimalBirthDateAttribute>()?.FirstOrDefault();
            int limitYear = 0;
            int limitMonth = 0;
            int limitDay = 0;
            if (attr != null)
            {
                limitYear = attr.Year;
                limitMonth = attr.Month;
                limitDay = attr.Day;
            }
            Console.WriteLine("MinimalBirthDate: " + new DateTime(limitYear, limitMonth, limitDay).ToString());
            Console.WriteLine("ContactBirthDate: " + contact.BirthDate.ToString());
            bool isValid = ValidateBirthDate(contact, limitYear, limitMonth, limitDay);
            Console.WriteLine(isValid);
        }
        
        //creating source array of contacts
        public static ArrayList CreateArrayListOfContacts()
        {
            ArrayList sourceArray = new ArrayList();
            sourceArray.Add(new Contact("a", "a", "a", "a", "a", "a", "a", new DateTime(1, 1, 1)));
            sourceArray.Add(new Contact("a", "a", "a", "a", "a", "a", "a", new DateTime(1, 1, 1)));
            sourceArray.Add(new Contact("a", "a", "a", "a", "a", "a", "a", new DateTime(1, 1, 1)));
            sourceArray.Add(new Contact("b", "b", "b", "b", "b", "b", "b", new DateTime(2, 2, 2)));
            sourceArray.Add(new Contact("c", "c", "c", "c", "c", "c", "c", new DateTime(3, 3, 3)));
            sourceArray.Add(new Contact("d", "d", "d", "d", "d", "d", "d", new DateTime(4, 4, 4)));
            sourceArray.Add(new Contact("e", "e", "e", "e", "e", "e", "e", new DateTime(5, 5, 5)));
            sourceArray.Add(new Contact("f", "f", "f", "f", "f", "f", "f", new DateTime(6, 6, 6)));
            sourceArray.Add(new Contact("g", "g", "g", "g", "g", "g", "g", new DateTime(7, 7, 7)));
            sourceArray.Add(new Contact("h", "h", "h", "h", "h", "h", "h", new DateTime(8, 8, 8)));
            sourceArray.Add(new Contact("h", "h", "h", "h", "h", "h", "h", new DateTime(8, 8, 8)));
            return sourceArray;
        }
        //running task with selected filled datastructures
        public static void DataStructuresTaskAndCheckAttribute()
        {
            ArrayList sourceArray = CreateArrayListOfContacts();
            var contactsList = CreateListOfContactsFromSource(sourceArray);
            var contactsLinkedList = CreateLinkedListOfContactsFromSource(sourceArray);
            var contactsQueue = CreateQueueOfContactsFromSource(sourceArray);
            var contactsStack = CreateStackOfContactsFromSource(sourceArray);
            var contactsDictionary = CreateDictionaryOfContactsFromSource(sourceArray);
            var contactsHashtable = CreateHashtableOfContactsFromSource(sourceArray);
            ListBypass(contactsList);
            LinkedListBypass(contactsLinkedList);
            QueueBypass(contactsQueue);
            StackBypass(contactsStack);
            DictionaryBypass(contactsDictionary);
            HashtableBypass(contactsHashtable);
            Contact temp = new Contact("a", "a", "a", "a", "a", "a", "a", new DateTime(1, 1, 1));
            HashtableDeleteElement(contactsHashtable, temp);
            HashtableBypass(contactsHashtable);
            DictionaryDeleteElement(contactsDictionary, temp);
            DictionaryBypass(contactsDictionary);
            CheckBirthDateProperty();
        }
    }
}
