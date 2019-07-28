using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ContactDLL
{
    [ClassDescription(Description = "Контакт")]
    public sealed class Contact : Person, ICloneable
    {
        private string _Surname;
        private string _Name;
        private string _Patronymic;
        private string _TaxpayerIdentificationNumber;
        private string _Position;
        private string _Sex;
        private DateTime _BirthDate;
        private string _TelephoneNumber;
        public Contact()
        {

        }
        public Contact(string surname, string name, string patronymic, string taxpayerIdentificationNumber, string position, string sex, string telephoneNumber, DateTime birthDate)
        {
            _Surname = surname;
            _Name = name;
            _Patronymic = patronymic;
            _TaxpayerIdentificationNumber = taxpayerIdentificationNumber;
            _Position = position;
            _Sex = sex;
            _BirthDate = birthDate;
            _TelephoneNumber = telephoneNumber;
        }

        public override string Surname
        {
            get => _Surname;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                    throw new Exception("Строка пустая или имеет длину менее 3-х символов");
            }
        }

        public override string Name
        {
            get => _Name;
            set
            {
                _Name = value;
            }
        }

        public override string Patronymic
        {
            get => _Patronymic;
            set
            {
                _Patronymic = value;
            }
        }

        public string TaxpayerIdentificationNumber
        {
            get => _TaxpayerIdentificationNumber;
            set
            {
                _TaxpayerIdentificationNumber = value;
            }
        }

        public string Position
        {
            get => _Position;
            set
            {
                _Position = value;
            }
        }
        public override string Sex
        {
            get => _Sex;
            set
            {
                _Sex = value;
            }
        }

        [MinimalBirthDate(2001, 10, 3)] //YYYY.MM.DD
        public DateTime BirthDate
        {
            get => _BirthDate;
            set
            {
                _BirthDate = value;
            }
        }

        public string TelephoneNumber
        {
            get => _TelephoneNumber;
            set
            {
                _TelephoneNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Concat(new object[] { Surname, " ", Name, " ",
                Patronymic, " ", TaxpayerIdentificationNumber, " ",
                Position, " ", Sex, " ", BirthDate, " ", TelephoneNumber});
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Contact contact = obj as Contact;
            if (contact == null)
                return false;
            return contact.Surname.Equals(this.Surname) &&
                contact.Name.Equals(this.Name) &&
                contact.Patronymic.Equals(this.Patronymic) &&
                contact.TaxpayerIdentificationNumber.Equals(this.TaxpayerIdentificationNumber) &&
                contact.Position.Equals(this.Position) &&
                contact.Sex.Equals(this.Sex) &&
                contact.BirthDate == this.BirthDate && contact.TelephoneNumber.Equals(this.TelephoneNumber) ;
        }
        public override int GetHashCode()
        {
            return new { Surname, Name, Patronymic, TaxpayerIdentificationNumber, Position, Sex, BirthDate, TelephoneNumber }.GetHashCode();
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
            temp._TelephoneNumber = _TelephoneNumber;
            return temp;
        }
        #endregion
    }
}