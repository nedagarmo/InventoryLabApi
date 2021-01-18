using Inventory.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Models
{
    public class Stock : BaseModel
    {
        public Guid WarehouseId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Decimal AccumulatedValue { get; set; }

        public virtual Warehouse Wharehouse { get; set; }
        public virtual Product Product { get; set; }
    }
}
