using System.Data.Entity.ModelConfiguration;
using BTL.Domain.Core.UserManagement;

namespace BTL.DataAccess.Mappings.UserManagement
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(p => p.Id).HasOptional(x=>x.Roles);

            Property(p => p.Id);//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.UserName).IsRequired().HasMaxLength(64);
            Property(p => p.Password).IsRequired();
            Property(p => p.Theme).IsRequired();
            Property(p => p.CreatedAt);
            Property(p => p.UpdatedAt);

            HasMany(p => p.Roles).WithMany(c => c.Users);
        }
    }
}