using CuarAuthentication.Domain.Features;
using CuarAuthentication.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuarAuthentication.Domain.Configurations.Features
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable(name: "Features");
            builder.HasMany(x => x.UserFeatures)
                .WithOne(f => f.Feature)
                .HasForeignKey(f => f.FeatureId);
        }
    }
}
