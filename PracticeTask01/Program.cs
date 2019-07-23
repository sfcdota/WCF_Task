using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ContactDLL;

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
            ContactFileSaver saver = new ContactFileSaver();
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



        static void Main(string[] args)
        {
            CheckBirthDateProperty();
            Console.ReadKey();
            
        }
    }
}
