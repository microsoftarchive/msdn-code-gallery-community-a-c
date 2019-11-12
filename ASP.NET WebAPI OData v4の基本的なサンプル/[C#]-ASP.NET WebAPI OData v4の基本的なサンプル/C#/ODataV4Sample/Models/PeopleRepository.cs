using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataV4Sample.Models
{
    public class PeopleRepository
    {
        private static readonly List<Person> People;

        static PeopleRepository()
        {
            People = Enumerable.Range(1, 100)
                .Select(i => new Person
                {
                    Id = i,
                    Name = "tanaka" + i,
                    Age = 10 + i % 30
                })
                .ToList();
        }

        public IEnumerable<Person> GetPeople(int? skip = null, int? top = null)
        {
            var result = People.AsEnumerable();
            if (skip != null)
            {
                result = result.Skip(skip.Value);
            }
            if (top != null)
            {
                result = result.Take(top.Value);
            }
            return result.Select(x => x.Clone());
        }

        public Person Get(int id)
        {
            var result = People.FirstOrDefault(x => x.Id == id);
            if (result == null) { return null; }

            return result.Clone();
        }

        public bool Update(int id, Person p)
        {
            var target = People.FirstOrDefault(x => x.Id == id);
            if (target == null) { return false; }

            target.Name = p.Name;
            target.Age = p.Age;
            return true;
        }

        public int Add(Person p)
        {
            var newId = People.Count() + 1;
            p.Id = newId;
            People.Add(p);
            return newId;
        }

        public bool Delete(int id)
        {
            var target = People.FirstOrDefault(x => x.Id == id);
            if (target == null) { return false; }

            People.Remove(target);
            return true;
        }
    }
}