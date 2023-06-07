using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = RideShare.Domain.Entities.Type;

namespace RideShare.DataAccess.Configurations
{
    public class TypeConfiguration : EntityConfiguration<Type>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Type> builder)
        {
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
