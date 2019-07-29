using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using System.IO;

namespace ContactDLL
{
    public class XMLContactFormatter: IFormatter
    {
        /*
        private readonly Contact _Contact;
        public XMLContactFormatter(Contact contact)
        {
            _Contact = contact;
        }
        */
        //formatting IEnumerable collection to xml
        public string Format(IEnumerable<Contact> contacts, string dataFormat)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("contacts");
            xmlDoc.AppendChild(rootNode);


            foreach (Contact contact in contacts)
            {
                XmlNode userNode = xmlDoc.CreateElement("contact");
                rootNode.AppendChild(userNode);
                XmlAttribute contactAttribute = xmlDoc.CreateAttribute("Surname");
                contactAttribute.Value = contact.Surname;
                userNode.Attributes.Append(contactAttribute);
                contactAttribute = xmlDoc.CreateAttribute("Name");
                contactAttribute.Value = contact.Name;
                userNode.Attributes.Append(contactAttribute);
                contactAttribute = xmlDoc.CreateAttribute("Patronymic");
                contactAttribute.Value = contact.Patronymic;
                userNode.Attributes.Append(contactAttribute);
                contactAttribute = xmlDoc.CreateAttribute("TaxpayerIdentificationNumber");
                contactAttribute.Value = contact.TaxpayerIdentificationNumber;
                userNode.Attributes.Append(contactAttribute);
                contactAttribute = xmlDoc.CreateAttribute("Position");
                contactAttribute.Value = contact.Position;
                userNode.Attributes.Append(contactAttribute);
                contactAttribute = xmlDoc.CreateAttribute("Sex");
                contactAttribute.Value = contact.Sex;
                userNode.Attributes.Append(contactAttribute);
                contactAttribute = xmlDoc.CreateAttribute("TelephoneNumber");
                contactAttribute.Value = contact.TelephoneNumber;
                userNode.Attributes.Append(contactAttribute);
                contactAttribute = xmlDoc.CreateAttribute("BirthDate");
                contactAttribute.Value = contact.BirthDate.ToString(dataFormat);
                userNode.Attributes.Append(contactAttribute);
                // BirthDate.ToString(ConfigurationManager.AppSettings["DataFormat"])
            }
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                xmlDoc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
