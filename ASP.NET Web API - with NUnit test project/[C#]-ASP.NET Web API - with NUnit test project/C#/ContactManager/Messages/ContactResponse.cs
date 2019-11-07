using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactManager.Models;

namespace ContactManager.Messages
{
    public class ContactResponse
    {
        public List<ContactDTO> contacts;

        public ContactDTO contact;
    }
}