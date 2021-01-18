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
    public class GetMovementByIdHandler : IRequestHandler<GetMovementByIdCommand, MovementDTO>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;

        public GetMovementByIdHandler(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<MovementDTO> Handle(GetMovementByIdCommand request, CancellationToken cancellationToken) =>
            _mapper.Map<MovementDTO>(await _movementRepository.GetByIdAsync(request.Id));
    }
}
