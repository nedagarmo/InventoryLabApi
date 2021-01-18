using Inventory.Entities.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Commands
{
    public class GetWarehouseByIdCommand : IRequest<WarehouseDTO>
    {
        public Guid Id { get; set; }
    }
}
