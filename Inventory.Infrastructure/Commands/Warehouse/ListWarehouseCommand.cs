using Inventory.Entities.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Commands
{
    public class ListWarehouseCommand : IRequest<List<WarehouseListDTO>>
    {
        public int? Page { get; set; }
        public int? Size { get; set; }
    }
}
