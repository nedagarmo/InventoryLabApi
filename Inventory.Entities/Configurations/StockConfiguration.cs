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
    class StockConfiguration : BaseConfiguration<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.WarehouseId).IsRequired();
            builder.Property(e => e.ProductId).IsRequired();
            builder.Property(e => e.Quantity).IsRequired();
            builder.Property(e => e.AccumulatedValue).IsRequired().HasPrecision(18, 2);
        }
    }
}
