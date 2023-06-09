using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.DataAccess.Configurations
{
    public class RatingConfiguration : EntityConfiguration<Rating>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(x => x.Score).IsRequired();
        }
    }
}
