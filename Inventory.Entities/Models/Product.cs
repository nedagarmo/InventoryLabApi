using Inventory.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
