using CuarAuthentication.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuarAuthentication.Domain.Configurations
{
	public class ApplicationUserTokenConfiguration : IEntityTypeConfiguration<ApplicationUserToken>
	{
		public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
		{
			builder.ToTable(name: "UserTokens");
		}
	}
}