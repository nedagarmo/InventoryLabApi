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
    public class CreateMovementHandler : IRequestHandler<CreateMovementCommand, MovementDTO>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMovementTypeRepository _movementTypeRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateMovementHandler(IMovementRepository movementRepository, 
                                     IMovementTypeRepository movementTypeRepository,
                                     IStockRepository stockRepository,
                                     IWarehouseRepository warehouseRepository,
                                     IProductRepository productRepository,
                                     IMapper mapper)
        {
            _movementRepository = movementRepository;
            _movementTypeRepository = movementTypeRepository;
            _stockRepository = stockRepository;
            _warehouseRepository = warehouseRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<MovementDTO> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Movement>(request.Movement);

                entity.Type = await _movementTypeRepository.GetByIdAsync(entity.TypeId);
                if (entity.Type == null) 
                {
                    throw new Exception("No se encontró el tipo de movimiento especificado");
                }

                entity.Product = await _productRepository.GetByIdAsync(entity.ProductId);
                if (entity.Product == null)
                {
                    throw new Exception("No se encontró el producto especificado");
                }

                entity.WarehouseOrigin = await _warehouseRepository.GetByIdAsync(entity.WarehouseOriginId);
                if (entity.WarehouseOrigin == null)
                {
                    throw new Exception("No se encontró la bodega de origen del movimiento");
                }

                entity.Id = Guid.NewGuid();
                entity.CreatedAt = DateTime.UtcNow;
                var movement = await _movementRepository.AddAsync(entity);
                var originStock = await _stockRepository.GetByProductAndWarehouseIdAsync(movement.ProductId, movement.WarehouseOriginId);

                // Si el stock no existe, lo creamos.
                if (originStock == null)
                {
                    await _stockRepository.AddAsync(new Stock()
                    {
                        Id = Guid.NewGuid(),
                        ProductId = movement.ProductId,
                        Quantity = 0,
                        WarehouseId = movement.WarehouseOriginId,
                        AccumulatedValue = 0,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                // Realizamos la salida o entrada en la bodega de origen del movimiento
                if (movement.Type.IsOutlet)
                {
                    if (originStock.Quantity == 0 || (originStock.Quantity - movement.Quantity) < 0) 
                    {
                        throw new Exception("No se puede realizar la salida ya que la existencia del producto no es suficiente.");
                    }

                    originStock.Quantity -= movement.Quantity;
                    originStock.ModifiedAt = DateTime.UtcNow;
                    originStock.AccumulatedValue -= movement.Price.Value;
                    
                }
                else
                {
                    originStock.Quantity += movement.Quantity;

                    if (entity.WarehouseOrigin.MaximumQuantity < originStock.Quantity)
                        throw new Exception("No se puede realizar la entrada al almacen porque se excedería la capacidad máxima de la bodega");

                    originStock.ModifiedAt = DateTime.UtcNow;
                    originStock.AccumulatedValue += movement.Price.Value;
                }

                await _stockRepository.UpdateAsync(originStock);

                // Comprobamos que sea una transferencia para afectar el stock de la bodega de destino.
                if (movement.Type.IsTransfer)
                {
                    if (movement.WarehouseDestination == null)
                    {
                        throw new Exception("No se proporcionó una bodega de destino correcta.");
                    }

                    entity.WarehouseDestination = await _warehouseRepository.GetByIdAsync(entity.WarehouseDestinationId.Value);
                    if (entity.WarehouseDestination == null)
                    {
                        throw new Exception("No se encontró la bodega de destino del movimiento");
                    }

                    var destinationStock = await _stockRepository.GetByProductAndWarehouseIdAsync(movement.ProductId, movement.WarehouseDestinationId.Value);

                    if (destinationStock == null)
                    {
                        await _stockRepository.AddAsync(new Stock()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = movement.ProductId,
                            Quantity = 0,
                            WarehouseId = movement.WarehouseDestinationId.Value,
                            AccumulatedValue = 0,
                            CreatedAt = DateTime.UtcNow
                        });
                    }

                    destinationStock.Quantity += movement.Quantity;
                    if (entity.WarehouseDestination.MaximumQuantity < destinationStock.Quantity)
                        throw new Exception("No se puede realizar el traslado porque se excedería la capacidad máxima de la bodega");

                    destinationStock.AccumulatedValue += movement.Price.Value;
                    destinationStock.ModifiedAt = DateTime.UtcNow;
                    await _stockRepository.UpdateAsync(destinationStock);
                }

                return _mapper.Map<MovementDTO>(movement);
            }
            catch
            {
                throw;
            }
        }
    }
}
