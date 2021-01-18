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
    class WarehouseConfiguration : BaseConfiguration<Warehouse>
    {
        public override void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Location).IsRequired().HasMaxLength(200);
            builder.Property(e => e.MaximumQuantity).IsRequired();
        }
    }
}
