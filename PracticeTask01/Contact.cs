using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask01
{
    [ClassDescription(Description = "Контакт")]
    class Contact
    {
        private string surname { get; set; }
        private string name { get; set; }
        private string patronymic { get; set; }
        private string taxpayerIdentificationNumber { get; set; }
        private string Position { get; set; }
        private char sex { get; set; }
        private DateTime birthDate { get; [MinimalBirthDate(MinimalDate = new DateTime(2000, 01, 10))]set; }
        
    }
}
