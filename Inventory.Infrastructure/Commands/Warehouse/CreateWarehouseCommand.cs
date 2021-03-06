﻿using Inventory.Entities.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Commands
{
    public class CreateWarehouseCommand : IRequest<WarehouseDTO>
    {
        public WarehouseDTO Warehouse { get; set; }
    }
}
