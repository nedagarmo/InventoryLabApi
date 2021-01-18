using Inventory.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Models
{
    public class MovementType : BaseModel
    {
        public string Name { get; set; }

        /// <summary>
        /// Esta propiedad determina si el tipo de movimiento es Salida o Entrada de productos.
        /// Esto se realiza debido a que entre los tipos de movimiento pueden haber entradas tales como
        /// una compra, un traslado, entre otros; y entre las salidas se puede presentar
        /// un préstamo, un traslado, una remisión, una garantía, una venta, entre otros.
        /// </summary>
        public bool IsOutlet { get; set; }
        public bool IsTransfer { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
    }
}
