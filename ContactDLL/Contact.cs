using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ContactDLL
{
    [ClassDescription(Description = "Контакт")]
    public class Contact : ICloneable
    {
        private string _Surname;
        private string _Name;
        private string _Patronymic;
        private string _TaxpayerIdentificationNumber;
        private string _Position;
        private string _Sex;
        private DateTime _BirthDate;
        public Contact()
        {

        }
        public Contact(string surname, string name, string patronymic, string taxpayerIdentificationNumber, string position, string sex, DateTime birthDate)
        {
            _Surname = surname;
            _Name = name;
            _Patronymic = patronymic;
            _TaxpayerIdentificationNumber = taxpayerIdentificationNumber;
            _Position = position;
            _Sex = sex;
            _BirthDate = birthDate;
        }

        public string Surname
        {
            get => _Surname;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                    throw new Exception("Строка пустая или имеет длину менее 3-х символов");
            }
        }

        public string Name
        {
            get; set;
        }

        public string Patronymic
        {
            get; set;
        }

        public string TaxpayerIdentificationNumber
        {
            get; set;
        }

        public string Position
        {
            get; set;
        }

        public string Sex
        {
            get; set;
        }

        [MinimalBirthDate(2001, 10, 3)] //YYYY.MM.DD
        public DateTime BirthDate
        {
            get; set;
        }

        #region
        public object Clone()
        {
            Contact temp = new Contact();
            temp._Surname = _Surname;
            temp._Name = _Name;
            temp._Patronymic = _Patronymic;
            temp._TaxpayerIdentificationNumber = _TaxpayerIdentificationNumber;
            temp._Position = _Position;
            temp._Sex = _Sex;
            temp._BirthDate = new DateTime(BirthDate.Year, BirthDate.Month, BirthDate.Day);
            return temp;
        }
        #endregion
    }
}