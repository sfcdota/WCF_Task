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
using LoggerNamespace;
namespace PracticeTask01
{
    partial class Program
    {
        static void Main(string[] args)
        { 
            var logger = new Logger().CreateLogger(LoggersEnum.log4net);
            logger.Info("Program started");
            DataStructuresTaskAndCheckAttribute();
            var sourceArray = CreateArrayListOfContacts();
            var contactsList = CreateListOfContactsFromSource(sourceArray);
            bool rewriteAllowed = Convert.ToBoolean(ConfigurationManager.AppSettings["RewriteAllowed"]);
            string dataFormat = ConfigurationManager.AppSettings["DataFormat"];
            string path = Path.Combine(Environment.CurrentDirectory, "SavedContacts");

            using (ContactFileSaver contactFileSaver = new ContactFileSaver(rewriteAllowed, dataFormat, logger))
            {
                contactFileSaver.Save(path, contactsList, logger);
            }
            Console.ReadKey();
            logger.Info("program finished");
            
        }
    }
}