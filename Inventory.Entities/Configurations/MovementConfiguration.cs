using Inventory.Entities.Abstractions;
using Inventory.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Configurations
{
    class MovementConfiguration : BaseConfiguration<Movement>
    {
        public override void Configure(EntityTypeBuilder<Movement> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.TypeId).IsRequired();
            builder.Property(e => e.WarehouseOriginId).IsRequired();
            builder.HasOne(e => e.WarehouseOrigin).WithMany(e => e.OriginMovements)
                .HasForeignKey(k => k.WarehouseOriginId);
            builder.HasOne(e => e.WarehouseDestination).WithMany(e => e.DestinationMovements)
                .HasForeignKey(k => k.WarehouseDestinationId);
            builder.Property(e => e.ProductId).IsRequired();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.Quantity).IsRequired();
            builder.Property(e => e.Price).HasPrecision(18, 2);
        }
    }
}
