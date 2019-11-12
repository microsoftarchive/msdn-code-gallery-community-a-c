using System;

namespace ConcreteLibrary
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string Role { get; set; }
        public DateTime BirthDay { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Role}";
        }
    }
}
