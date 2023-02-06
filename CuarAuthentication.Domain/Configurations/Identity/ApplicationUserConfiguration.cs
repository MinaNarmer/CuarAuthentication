using CuarAuthentication.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuarAuthentication.Domain.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable(name: "Users");
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasMany(u => u.UserFeatures).WithOne(x => x.User)
                .HasForeignKey(u => u.ApplicationUserId);
        }
    }
}