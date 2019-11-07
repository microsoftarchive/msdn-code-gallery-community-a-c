using System.Data.Entity.ModelConfiguration;
using BTL.Domain.Core.UserManagement;

namespace BTL.DataAccess.Mappings.UserManagement
{
    public class RoleMapping : EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            HasKey(p => p.Id).HasOptional(x => x.Users);

            Property(p => p.Id);
            Property(p => p.Name).IsRequired().HasMaxLength(128);
            Property(p => p.CreatedAt);
            Property(p => p.UpdatedAt);

            HasMany(p => p.Users).WithMany(c => c.Roles);
        }
    }
}