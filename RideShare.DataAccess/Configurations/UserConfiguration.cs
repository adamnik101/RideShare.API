using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.Domain.Entities;

namespace RideShare.DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            
            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Gender)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Rides)
                .WithOne(x => x.Driver)
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}