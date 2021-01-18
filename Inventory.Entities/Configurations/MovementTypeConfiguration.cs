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
    class MovementTypeConfiguration : BaseConfiguration<MovementType>
    {
        public override void Configure(EntityTypeBuilder<MovementType> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(150);
            builder.Property(e => e.IsOutlet).IsRequired();
            builder.Property(e => e.IsTransfer).IsRequired();

            List<MovementType> Types = new List<MovementType>()
            {
                new MovementType() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Entrada por compra",
                    IsOutlet = false,
                    IsTransfer = false,
                    CreatedAt = DateTime.UtcNow
                },
                new MovementType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Salida por venta",
                    IsOutlet = true,
                    IsTransfer = false,
                    CreatedAt = DateTime.UtcNow
                },
                new MovementType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Entrada por traslado",
                    IsOutlet = false,
                    IsTransfer = true,
                    CreatedAt = DateTime.UtcNow
                },
                new MovementType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Salida por traslado",
                    IsOutlet = true,
                    IsTransfer = true,
                    CreatedAt = DateTime.UtcNow
                }
            };
            builder.HasData(Types);
        }
    }
}
