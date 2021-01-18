using Inventory.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Models
{
    public class Movement : BaseModel
    {
        public Guid TypeId { get; set; }
        public Guid WarehouseOriginId { get; set; }
        public Guid? WarehouseDestinationId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public Decimal? Price { get; set; }

        public virtual MovementType Type { get; set; }
        public virtual Warehouse WarehouseOrigin { get; set; }
        public virtual Warehouse WarehouseDestination { get; set; }
        public virtual Product Product { get; set; }
    }
}
