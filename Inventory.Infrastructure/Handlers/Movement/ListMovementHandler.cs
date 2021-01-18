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
    public class ListMovementHandler : IRequestHandler<ListMovementCommand, List<MovementDTO>>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;

        public ListMovementHandler(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<List<MovementDTO>> Handle(ListMovementCommand request, CancellationToken cancellationToken) =>
            _mapper.Map<List<MovementDTO>>(await _movementRepository.GetPageAsync(request.Page, request.Size));
    }
}
