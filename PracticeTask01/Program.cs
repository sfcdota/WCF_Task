using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ContactDLL;
using System.IO;
using log4net;
using System.Configuration;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace PracticeTask01
{
    partial class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log.Info("Program started");
            DataStructuresTaskAndCheckAttribute();
            var sourceArray = CreateArrayListOfContacts();
            var contactsList = CreateListOfContactsFromSource(sourceArray);
            bool rewriteAllowed = Convert.ToBoolean(ConfigurationManager.AppSettings["RewriteAllowed"]);
            string dataFormat = ConfigurationManager.AppSettings["DataFormat"];
            string path = Path.Combine(Environment.CurrentDirectory, "SavedContacts");
            //var formatterfactory = new Formatter().CreateFormatter(Extensions.CSV, contactsList);
            //formatterfactory.Format(contactsList);

            using (ContactFileSaver contactFileSaver = new ContactFileSaver(rewriteAllowed, dataFormat, log))
            {
                contactFileSaver.Save(path, contactsList, log);
            }
            Console.ReadKey();
            log.Info("program finished");
        }
    }
}
/* сделать так, чтобы переход с одного логгера на другой был минимален по изменениям в коде
 */