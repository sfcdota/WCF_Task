using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.XmlConfiguration;
using System.Configuration;
using LoggerNamespace;
namespace ContactDLL
{
    public sealed class ContactFileSaver : IDisposable
    {
        private FileStream _stream = null; //можно засунуть в сейв вместе с инициализацией, но по заданию - переменная класса :(
        private bool _RewriteAllowed;
        private string _DataFormat;
        private static ILogger _Logger;
        public ContactFileSaver(bool rewriteAllowed, string dataFormat, ILogger logger)
        {
            _RewriteAllowed = rewriteAllowed;
            _DataFormat = dataFormat;
            _Logger = logger;
        }
        //Get final path due to settings
        public string ExtendedPathDueToRewriteSettingsAndExtension(string path, string enteredExtension)
        {
            int i = 1;
            string baseName = path;
            path = Path.Combine(baseName + "." + enteredExtension);
            if (!_RewriteAllowed)//true or false value
                while (File.Exists(path))
                {
                    path = Path.Combine(baseName + "-" + i + "." + enteredExtension);
                    i++;
                }
            return path;
        }
        //save collection to the selected path
        public void Save(string path, IEnumerable<Contact> contacts, ILogger logger)
        {
            Console.WriteLine("Enter needed extension for output file");
            string enteredExtenstion = Console.ReadLine().ToUpper();
            if (Enum.TryParse(enteredExtenstion, out Extensions extensions))
            {
                Console.WriteLine("Saving...");
                path = ExtendedPathDueToRewriteSettingsAndExtension(path, enteredExtenstion);
                _stream = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter writer = new StreamWriter(_stream);
                var formatterfactory = new Formatter().CreateFormatter(extensions, contacts);
                logger.Info(extensions + "FormatterFactory created due to user input");
                writer.WriteLine(formatterfactory.Format(contacts, _DataFormat));
                writer.Close();
                Console.WriteLine("Save completed");
            }
            else
            {
                Console.WriteLine("Save failed. Entered extension {0} is not exitst", enteredExtenstion);
                logger.Info("Save failed. Entered extension " + enteredExtenstion + " is not exist");
            }
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