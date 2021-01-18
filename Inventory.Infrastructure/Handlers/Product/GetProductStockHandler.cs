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
    public class GetProductStockHandler : IRequestHandler<GetProductStockCommand, ProductStockDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetProductStockHandler(IProductRepository productRepository, 
                                      IStockRepository stockRepository,
                                      IMapper mapper)
        {
            _productRepository = productRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<ProductStockDTO> Handle(GetProductStockCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductStockDTO>(await _productRepository.GetByIdAsync(request.Id));
            product.Stocks = _mapper.Map<List<StockDTO>>(await _stockRepository.GetByProductIdAsync(request.Id));
            return product;
        }
    }
}
