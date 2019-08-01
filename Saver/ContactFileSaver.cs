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
    /// <summary>
    /// Класс, предназначенный для сохранения коллекции контактов 
    /// </summary>
    public sealed class ContactFileSaver : IDisposable
    {
        private FileStream _stream = null; //можно засунуть в сейв вместе с инициализацией, но по заданию - переменная класса :(
        private bool _RewriteAllowed;
        private string _DataFormat;
        private static ILogger _Logger;
        private PathChecker _PathChecker = null;
        public ContactFileSaver(bool rewriteAllowed, string dataFormat, ILogger logger)
        {
            _RewriteAllowed = rewriteAllowed;
            _DataFormat = dataFormat;
            _Logger = logger;
            _PathChecker = new PathChecker(rewriteAllowed);
        }

        /// <summary>
        /// Сохранение коллекции контактов в указанную директорию с запросом формата у пользователя через консоль
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contacts"></param>
        /// <param name="logger"></param>
        public void Save(string path, IEnumerable<Contact> contacts, ILogger logger)
        {
            Console.WriteLine("Enter needed extension for output file");
            string enteredExtenstion = Console.ReadLine().ToUpper();
            if (Enum.TryParse(enteredExtenstion, out Extensions extensions))
            {
                Console.WriteLine("Saving...");
                path = _PathChecker.GetRightPath(path, enteredExtenstion);
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
        #region
        public void Dispose()
        {
            _stream.Close();
            GC.SuppressFinalize(_stream);
        }
        #endregion
    }
}