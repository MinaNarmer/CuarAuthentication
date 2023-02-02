using CuarAuthentication.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuarAuthentication.Domain.Configurations
{
	public class ApplicationUserClaimConfiguration : IEntityTypeConfiguration<ApplicationUserClaim>
	{
		public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
		{
			builder.ToTable(name: "UserClaims");
		}
	}
}