using CuarAuthentication.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuarAuthentication.Domain.Configurations
{
	public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
	{
		public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
		{
			builder.ToTable(name: "UserRoles");
			builder.HasQueryFilter(e => !e.IsDeleted);
		}
	}
}