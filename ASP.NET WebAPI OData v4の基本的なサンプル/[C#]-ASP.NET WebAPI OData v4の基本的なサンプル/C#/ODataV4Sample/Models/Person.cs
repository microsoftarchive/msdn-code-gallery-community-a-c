
namespace ODataV4Sample.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person Clone()
        {
            return new Person
            {
                Id = this.Id,
                Name = this.Name,
                Age = this.Age
            };
        }
    }
}