using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.Domain.Entities;

namespace RideShare.DataAccess.Configurations
{
    public class BrandConfiguration : EntityConfiguration<Brand>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Models)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
