using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.Domain.Entities;

namespace RideShare.DataAccess.Configurations
{
    public class RideConfiguration : EntityConfiguration<Ride>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Ride> builder)
        {
            builder.HasOne(x => x.StartCity)
                .WithMany(x => x.StartRides)
                .HasForeignKey(x => x.StartCityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EndCity)
                .WithMany(x => x.EndRides)
                .HasForeignKey(x => x.EndCityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Car)
                .WithMany(x => x.Rides)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}