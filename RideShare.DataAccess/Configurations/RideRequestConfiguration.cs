using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.Domain.Entities;

namespace RideShare.DataAccess.Configurations
{
    public class RideRequestConfiguration : EntityConfiguration<RideRequest>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<RideRequest> builder)
        {
            builder.HasOne(x => x.FromUser)
                .WithMany(x => x.SentRideRequests)
                .HasForeignKey(x => x.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ToUser)
                .WithMany(x => x.ReceivedRideRequests)
                .HasForeignKey(x => x.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Ride)
                .WithMany(x => x.RideRequests)
                .HasForeignKey(x => x.RideId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}