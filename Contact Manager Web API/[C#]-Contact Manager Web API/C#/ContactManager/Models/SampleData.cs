using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public static class SampleData
    {
        static Contact[] sampleContacts = new Contact[]
            {
                new Contact { ContactId = 1, Name = "Glenn Block", Address = "1 Microsoft Way", City = "Redmond", State = "WA", Zip = "98052", Email = "gblock@microsoft.com", Twitter = "gblock" },
                new Contact { ContactId = 2, Name = "Howard Dierking", Address = "1 Microsoft Way", City = "Redmond", State = "WA", Zip = "98052", Email = "howard@microsoft.com", Twitter = "howard_dierking" },
                new Contact { ContactId = 3, Name = "Yavor Georgiev", Address = "1 Microsoft Way", City = "Redmond", State = "WA", Zip = "98052", Email = "yavorg@microsoft.com", Twitter = "digthepony" },
                new Contact { ContactId = 4, Name = "Jeff Handley", Address = "1 Microsoft Way", City = "Redmond", State = "WA", Zip = "98052", Email = "jeff.handley@microsoft.com", Twitter = "jeffhandley" },
                new Contact { ContactId = 5, Name = "Daniel Roth", Address = "1 Microsoft Way", City = "Redmond", State = "WA", Zip = "98052", Email = "daroth@microsoft.com", Twitter = "danroth27" },
            };

        public static Contact[] Contacts
        {
            get
            {
                return sampleContacts;
            }
        }
    }
}