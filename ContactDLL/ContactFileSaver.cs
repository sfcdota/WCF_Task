using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.XmlConfiguration;
namespace ContactDLL
{
    public sealed class ContactFileSaver : IDisposable
    {
        private FileStream _stream = null;
        public ContactFileSaver(string path)
        {
            _stream = new FileStream(path, FileMode.OpenOrCreate);
        }

        public void Save(Contact contact)
        {
            StreamWriter writer = new StreamWriter(_stream);
            writer.WriteLine(contact.Surname + ';'
                + contact.Name + ';'
                + contact.Patronymic + ';'
                + contact.TaxpayerIdentificationNumber + ';'
                + contact.Position + ';'
                + contact.Sex + ';'
                + contact.BirthDate
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