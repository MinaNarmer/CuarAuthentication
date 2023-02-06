using CuarAuthentication.Domain.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CuarAuthentication.Domain.Configurations.Features
{
    public class UserFeatureConfiguration : IEntityTypeConfiguration<UserFeature>

    {
        public void Configure(EntityTypeBuilder<UserFeature> builder)
        {
            builder.ToTable(name: "UserFeatures");
            builder.HasOne(x => x.User).WithMany(x => x.UserFeatures)
                .HasForeignKey(x => x.ApplicationUserId);
            builder.HasOne(x => x.Feature).WithMany(x => x.UserFeatures)
                .HasForeignKey(x => x.FeatureId);
        }
    }
}
