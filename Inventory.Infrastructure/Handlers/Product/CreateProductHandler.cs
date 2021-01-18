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
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, 
                                    IStockRepository stockRepository,
                                    IMapper mapper)
        {
            _productRepository = productRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(request.Product);
            entity.CreatedAt = DateTime.UtcNow;
            return _mapper.Map<ProductDTO>(await _productRepository.AddAsync(entity));
        }
    }
}
