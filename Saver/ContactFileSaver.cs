using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.XmlConfiguration;
using System.Configuration;
namespace ContactDLL
{
    public sealed class ContactFileSaver : IDisposable
    {
        private FileStream _stream = null; //можно засунуть в сейв вместе с инициализацией, но по заданию - переменная класса :(

       /* public bool CorrectExtension(string enteredExtension)
        {
            bool t = false;
            foreach(string x in Enum.GetNames(typeof(Extensions)))
            {
                if(enteredExtension.Equals(x))
                {
                    t = !t;
                    break;
                }
            }
            return t;
        }*/
        //Get final path due to settings
        public string ExtendedPathDueToRewriteSettingsAndExtension(string path, string enteredExtension)
        {
            StringBuilder builder = new StringBuilder();
            int i = 1;
            string baseName = path;
            path = Path.Combine(baseName + "." + enteredExtension);
            if (ConfigurationManager.AppSettings["RewriteAllowed"].Equals("no"))
                while (File.Exists(path))
                {
                    path = Path.Combine(baseName + "-" + i + "." + enteredExtension);
                    i++;
                }
            return path;
        }
        //save collection to the selected path
        public void Save(string path, IEnumerable<Contact> contacts)
        {
            Console.WriteLine("Enter needed extension for output file");
            string enteredExtenstion = Console.ReadLine().ToUpper();
            if (Enum.IsDefined(typeof(Extensions), enteredExtenstion))
            {
                Console.WriteLine("Saving...");
                Extensions extensions;
                Enum.TryParse(enteredExtenstion, out extensions);

                path = ExtendedPathDueToRewriteSettingsAndExtension(path, enteredExtenstion);
                _stream = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter writer = new StreamWriter(_stream);
                var formatterfactory = new Formatter().CreateFormatter(extensions, contacts);
                writer.WriteLine(formatterfactory.Format(contacts));
                writer.Close();
                Console.WriteLine("Save completed");
            }
            else
                Console.WriteLine("Save failed. Entered extension is not correct");
        }
        //interface implementation
        #region
        public void Dispose()
        {
            _stream.Close();
            GC.SuppressFinalize(_stream);
        }
        #endregion
    }
}