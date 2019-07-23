using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PracticeTask01
{
    [ClassDescription(Description = "Контакт")]
    class Contact : ICloneable
    {
        private string _Surname;
        private string _Name;
        private string _Patronymic;
        private string _TaxpayerIdentificationNumber;
        private string _Position;
        private string _Sex;
        private DateTime _BirthDate;


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
            get => _Name;
            set => _Name = value;
        }

        public string Patronymic
        {
            get => _Patronymic;
            set => _Patronymic = value;
        }

        public string TaxpayerIdentificationNumber
        {
            get => _TaxpayerIdentificationNumber;
            set => _TaxpayerIdentificationNumber = value;
        }

        public string Position
        {
            get => _Position;
            set => _Position = value;
        }

        public string Sex
        {
            get => _Sex;
            set => _Sex = value;
        }

        [MinimalBirthDate(2001, 10, 3)] //YYYY.MM.DD
        public DateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                    _BirthDate = value;
            }
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