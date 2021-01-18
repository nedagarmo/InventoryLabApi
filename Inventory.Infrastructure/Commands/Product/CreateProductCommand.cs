using Inventory.Entities.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Commands
{
    public class CreateProductCommand : IRequest<ProductDTO>
    {
        public ProductDTO Product { get; set; }
    }
}
