using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask01
{
    [ClassDescription(Description = "Контакт")]
    class Contact : ICloneable
    {
        private string surname,
        name,
        patronymic,
        taxpayerIdentificationNumber,
        position,
        sex,
        birthDate;

        public string Surname
        {
            get => surname;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                    throw new Exception("Строка пустая или имеет длину менее 3-х символов");
            }
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Patronymic
        {
            get => patronymic;
            set => patronymic = value;
        }

        public string TaxpayerIdentificationNumber
        {
            get => taxpayerIdentificationNumber;
            set => taxpayerIdentificationNumber = value;
        }

        public string Position
        {
            get => position;
            set => position = value;
        }

        public string Sex
        {
            get => sex;
            set => sex = value;
        }

        [MinimalBirthDate(MinimalDate = "2000.01.01")] //YYYY.MM.DD
        public string BirthDate
        {
            get => birthDate;
            set
            {
                var type = GetType();
                var attributeValue = Attribute.GetCustomAttribute(type, typeof(MinimalBirthDateAttribute)) as MinimalBirthDateAttribute;
                if (string.Compare(value, attributeValue.MinimalDate) >= 0)
                    birthDate = value;
            }
        }

        #region
        public object Clone()
        {
            Contact temp = new Contact();
            temp.surname = string.Copy(surname);
            temp.name = string.Copy(name);
            temp.patronymic = string.Copy(patronymic);
            temp.taxpayerIdentificationNumber = string.Copy(taxpayerIdentificationNumber);
            temp.position = string.Copy(position);
            temp.sex = string.Copy(sex);
            temp.birthDate = string.Copy(birthDate);
            return temp;
        }
        #endregion
    }
}
