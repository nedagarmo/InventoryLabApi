using Inventory.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Models
{
    public class Warehouse : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MaximumQuantity { get; set; }

        public virtual ICollection<Movement> OriginMovements { get; set; }
        public virtual ICollection<Movement> DestinationMovements { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
