using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ContactDLL
{
    public sealed class ContactFileSaver : IDisposable
    {
        readonly string path = Path.Combine(Environment.CurrentDirectory, "SavedContacts.txt");
        private FileStream _stream = null;
        public ContactFileSaver()
        {
            _stream = new FileStream(path, FileMode.OpenOrCreate);
        }

        public void Save(Contact person)
        {
            StreamWriter writer = new StreamWriter(_stream);
            writer.WriteLine(person.Surname + ';'
                + person.Name + ';'
                + person.Patronymic + ';'
                + person.TaxpayerIdentificationNumber + ';'
                + person.Position + ';'
                + person.Sex + ';'
                + person.BirthDate
                );
            writer.Close();
        }

        #region
        public void Dispose()
        {
            _stream.Close();
            GC.SuppressFinalize(_stream);
        }
        #endregion
    }
}
