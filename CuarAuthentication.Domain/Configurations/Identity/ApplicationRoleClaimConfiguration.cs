using CuarAuthentication.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuarAuthentication.Domain.Configurations
{
	public class ApplicationRoleClaimConfiguration : IEntityTypeConfiguration<ApplicationRoleClaim>
	{
		public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
		{
			builder.ToTable(name: "RoleClaims");
		}
	}
}