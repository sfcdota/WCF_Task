﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    public class TXTContactFormatter: IFormatter
    {
        /*
        private readonly Contact _Contact;
        public TXTContactFormatter(Contact contact)
        {
            _Contact = contact;
        }
        */
        public string Format(IEnumerable<Contact> contacts)
        {
            StringBuilder output = new StringBuilder();
            foreach (Contact contact in contacts)
            {
                output.Append(contact);
            }
            return output.ToString();
        }
    }
}
