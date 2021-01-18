using AutoMapper;
using Inventory.Application.Commands;
using Inventory.Domain.Abstractions;
using Inventory.Entities.DTOs;
using Inventory.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Application.Handlers
{
    public class ListWarehouseHandler : IRequestHandler<ListWarehouseCommand, List<WarehouseListDTO>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public ListWarehouseHandler(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<List<WarehouseListDTO>> Handle(ListWarehouseCommand request, CancellationToken cancellationToken) =>
            _mapper.Map<List<WarehouseListDTO>>(await _warehouseRepository.GetPageAsync(request.Page, request.Size));
    }
}
