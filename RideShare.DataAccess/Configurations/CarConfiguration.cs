using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.Domain.Entities;

namespace RideShare.DataAccess.Configurations
{
    public class CarConfiguration : EntityConfiguration<Car>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.FirstRegistration).IsRequired();
            builder.Property(x => x.LicencePlate).IsRequired();
            builder.Property(x => x.NumberOfSeats).IsRequired();

            builder.HasOne(x => x.Owner)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Color)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.ColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Type)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Model)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}