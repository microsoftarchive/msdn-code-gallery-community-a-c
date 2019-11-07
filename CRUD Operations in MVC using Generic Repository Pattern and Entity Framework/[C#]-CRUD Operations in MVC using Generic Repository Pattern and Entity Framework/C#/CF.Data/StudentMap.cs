using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CF.Data
{
    public class StudentMap: EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FirstName).IsRequired();
            Property(t => t.LastName).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.EnrollmentNumber).IsRequired();
            ToTable("Student");
        }
    }
}
