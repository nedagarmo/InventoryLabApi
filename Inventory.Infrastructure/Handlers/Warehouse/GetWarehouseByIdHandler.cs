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
    public class GetWarehouseByIdHandler : IRequestHandler<GetWarehouseByIdCommand, WarehouseDTO>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetWarehouseByIdHandler(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<WarehouseDTO> Handle(GetWarehouseByIdCommand request, CancellationToken cancellationToken) =>
            _mapper.Map<WarehouseDTO>(await _warehouseRepository.GetByIdAsync(request.Id));
    }
}
