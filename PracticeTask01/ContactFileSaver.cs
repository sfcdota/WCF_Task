using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PracticeTask01
{
    class ContactFileSaver : IDisposable
    {
        FileStream stream;
        public ContactFileSaver()
        {
            FileStream newstream = new FileStream("SavedContacts.txt", FileMode.OpenOrCreate);
            stream = newstream;
        }

        public void Save(Contact person)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(person.Surname + ';'
                + person.Name + ';'
                + person.Patronymic + ';'
                + person.TaxpayerIdentificationNumber + ';'
                + person.Position + ';'
                + person.Sex + ';'
                + person.BirthDate
                );
        }

        #region
        public void Dispose()
        {
            stream.Close();
        }
        #endregion
    }
}
