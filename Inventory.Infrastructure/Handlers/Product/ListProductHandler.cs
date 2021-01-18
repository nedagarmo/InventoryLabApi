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
    public class ListProductHandler : IRequestHandler<ListProductCommand, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ListProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(ListProductCommand request, CancellationToken cancellationToken) =>
            _mapper.Map<List<ProductDTO>>(await _productRepository.GetPageAsync(request.Page, request.Size));
    }
}
