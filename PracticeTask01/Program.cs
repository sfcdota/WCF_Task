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
    class Program
    {
        public static bool ValidateBirthDate(Contact contact, int year, int month, int day)
        {
            DateTime temp = new DateTime(year, month, day);
            if (contact.BirthDate.Ticks > temp.Ticks)
                return true;
            else return false;
        }

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

        public static void SourceInput(ArrayList sourceArray)
        {
            sourceArray.Add(new Contact("a", "a", "a", "a", "a", "a", new DateTime(1, 1, 1)));
            sourceArray.Add(new Contact("a", "a", "a", "a", "a", "a", new DateTime(1, 1, 1)));
            sourceArray.Add(new Contact("a", "a", "a", "a", "a", "a", new DateTime(1, 1, 1)));
            sourceArray.Add(new Contact("b", "b", "b", "b", "b", "b", new DateTime(2, 2, 2)));
            sourceArray.Add(new Contact("c", "c", "c", "c", "c", "c", new DateTime(3, 3, 3)));
            sourceArray.Add(new Contact("d", "d", "d", "d", "d", "d", new DateTime(4, 4, 4)));
            sourceArray.Add(new Contact("e", "e", "e", "e", "e", "e", new DateTime(5, 5, 5)));
            sourceArray.Add(new Contact("f", "f", "f", "f", "f", "f", new DateTime(6, 6, 6)));
            sourceArray.Add(new Contact("g", "g", "g", "g", "g", "g", new DateTime(7, 7, 7)));
            sourceArray.Add(new Contact("h", "h", "h", "h", "h", "h", new DateTime(8, 8, 8)));
            sourceArray.Add(new Contact("h", "h", "h", "h", "h", "h", new DateTime(8, 8, 8)));
        }

        public static void ListBypass(List<Contact> contacts)
        {
            Console.WriteLine("Обход листа");
            foreach (var contact in contacts)
                Console.WriteLine(contact);
        }

        public static void LinkedListBypass(LinkedList<Contact> contacts)
        {
            Console.WriteLine("Обход связного листа");
            foreach (var contact in contacts)
                Console.WriteLine(contact);
        }

        public static void QueueBypass(Queue<Contact> contacts)
        {
            Console.WriteLine("Обход очереди");
            foreach (var contact in contacts)
                Console.WriteLine(contact);
        }

        public static void  StackBypass(Stack<Contact> contacts)
        {
            Console.WriteLine("Обход стека");
            foreach (var contact in contacts)
                Console.WriteLine(contact);
        }

        public static void DictionaryBypass(Dictionary<int, Contact> contacts)
        {
            Console.WriteLine("Обход словаря");
            foreach (KeyValuePair<int, Contact> contact in contacts)
                Console.WriteLine(contact.Value);
        }

        public static void HashtableBypass(Hashtable contacts)
        {
            Console.WriteLine("Обход хэш-таблицы");
            foreach (DictionaryEntry contact in contacts)
                Console.WriteLine(contact.Value);
        }

        public static void DictionaryDelete(Dictionary<int, Contact> contacts, Contact contact)
        {
            foreach(var dictionaryElement in contacts)
                if(dictionaryElement.Value.Equals(contact))
                {
                    contacts.Remove(dictionaryElement.Key);
                    break;
                }
        }

        public static void HashtableDelete(Hashtable hashtable, Contact contact)
        {
            foreach(DictionaryEntry hashtableElement in hashtable)
            {
                if (hashtableElement.Value.Equals(contact))
                {
                    hashtable.Remove(hashtableElement.Key);
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            ArrayList sourceArray = new ArrayList();
            SourceInput(sourceArray);
            var contactsList = new List<Contact>();
            var contactsLinkedList = new LinkedList<Contact>();
            var contactsQueue = new Queue<Contact>();
            var contactsStack = new Stack<Contact>();
            var contactsDictionary = new Dictionary<int, Contact>();
            var contactsHashtable = new Hashtable();
            int i = 1;
            foreach (object a in sourceArray)
            {
                contactsList.Add(a as Contact);
                contactsLinkedList.AddLast(a as Contact);
                contactsQueue.Enqueue(a as Contact);
                contactsStack.Push(a as Contact);
                contactsDictionary.Add(i, a as Contact);
                contactsHashtable.Add(i++, a as Contact);
            }
            ListBypass(contactsList);
            LinkedListBypass(contactsLinkedList);
            QueueBypass(contactsQueue);
            StackBypass(contactsStack);
            DictionaryBypass(contactsDictionary);
            HashtableBypass(contactsHashtable);
            Contact temp = new Contact("a", "a", "a", "a", "a", "a", new DateTime(1, 1, 1));
            HashtableDelete(contactsHashtable, temp);
            HashtableDelete(contactsHashtable, temp);
            HashtableDelete(contactsHashtable, temp);
            HashtableBypass(contactsHashtable);

            DictionaryDelete(contactsDictionary, temp);
            DictionaryBypass(contactsDictionary);
            CheckBirthDateProperty();
            ContactFileSaver contactFileSaver = new ContactFileSaver();
            contactFileSaver.Save(temp);
            contactFileSaver.Dispose();
            contactFileSaver.Dispose();
            Console.ReadKey();






            string contentFormat = "xml";
            Contact contact = new Contact();
            IFormatter formatter = FormatterFactory.CreateFormatter(contentFormat);

            string text = formatter.Format(contact);
            IPersonSaver saver = PersonSaverFactory.CreateSaver();



            string path = Path.Combine(Environment.CurrentDirectory, "SavedContacts.txt");

            saver.Save(path, text);

            FormattedContact formattedContact = new FormattedContact(contact);





        }
    }
}
