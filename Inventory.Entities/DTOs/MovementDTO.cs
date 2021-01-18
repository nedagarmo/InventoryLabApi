using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.DTOs
{
    public class MovementDTO
    {
        public Guid Type { get; set; }
        public Guid Product { get; set; }
        public Guid WarehouseOrigin { get; set; }
        public Guid? WarehouseDestination { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public Decimal? Price { get; set; }
    }
}
