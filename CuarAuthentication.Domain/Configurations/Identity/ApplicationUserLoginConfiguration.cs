using CuarAuthentication.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuarAuthentication.Domain.Configurations
{
	public class ApplicationUserLoginConfiguration : IEntityTypeConfiguration<ApplicationUserLogin>
	{
		public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
		{
			builder.ToTable(name: "UserLogins");
		}
	}
}