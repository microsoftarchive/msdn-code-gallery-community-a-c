using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class PeopleRepository : DbContext
    {
        public PeopleRepository() : base("name=ContactsEntities") { }
        //static List<Contacts> listPeople;
        

        public System.Data.Entity.DbSet<Contacts> Contacts { get; set; }

        public void Save(Contacts people)
        {
            
            Contacts.Add(people);
           // Configuration.ValidateOnSaveEnabled = false;
            SaveChanges();
        }

        public void ModifyUser(Contacts people)
        {
            var original = Contacts.Find(people.id);
            if (original != null)
            {
                Entry(original).CurrentValues.SetValues(people);// State = EntityState.Modified;
                // Contacts.Attach(people);
                SaveChanges();
            }
        }

        internal void Delete(Contacts people)
        {
            var user= from x in this.Contacts where x.id == people.id select x;
            this.Contacts.Remove(user.First<Contacts>());
            SaveChanges();
        }
    }
}