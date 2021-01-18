using Inventory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.DTOs
{
    public class StockDTO
    {
        public Guid Id { get; set; }
        public Guid WarehouseId { get; set; }
        public int Quantity { get; set; }
        public Decimal AccumulatedValue { get; set; }
    }
}
