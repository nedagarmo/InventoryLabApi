using AutoMapper;
using Inventory.Entities.DTOs;
using Inventory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Mappers
{
    public class ObjectMapperProfile: Profile
    {
        public ObjectMapperProfile()
        {
            // DTO a Entity
            CreateMap<ProductDTO, Product>();
            CreateMap<WarehouseDTO, Warehouse>()
                .ForMember(ent => ent.MaximumQuantity, opt => opt.MapFrom(dto => dto.Quantity));
            CreateMap<MovementDTO, Movement>()
                .ForMember(ent => ent.WarehouseOriginId, opt => opt.MapFrom(dto => dto.WarehouseOrigin))
                .ForMember(ent => ent.WarehouseDestinationId, opt => opt.MapFrom(dto => dto.WarehouseDestination))
                .ForMember(ent => ent.TypeId, opt => opt.MapFrom(dto => dto.Type))
                .ForMember(ent => ent.ProductId, opt => opt.MapFrom(dto => dto.Product))
                .ForMember(ent => ent.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(ent => ent.Date, opt => opt.MapFrom(dto => dto.Date))
                .ForMember(ent => ent.Price, opt => opt.MapFrom(dto => dto.Price))
                .ForAllOtherMembers(x => x.Ignore());

            // Entity a DTO
            CreateMap<Product, ProductDTO>();
            CreateMap<Stock, StockDTO>();
            CreateMap<Product, ProductStockDTO>();
            CreateMap<Warehouse, WarehouseDTO>()
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(ent => ent.MaximumQuantity));
            CreateMap<Movement, MovementDTO>()
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(ent => ent.Quantity))
                .ForMember(dto => dto.Date, opt => opt.MapFrom(ent => ent.Date))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(ent => ent.Price))
                .ForMember(dto => dto.WarehouseOrigin, opt => opt.MapFrom(ent => ent.WarehouseOriginId))
                .ForMember(dto => dto.WarehouseDestination, opt => opt.MapFrom(ent => ent.WarehouseDestinationId))
                .ForMember(dto => dto.Type, opt => opt.MapFrom(ent => ent.TypeId))
                .ForMember(dto => dto.Product, opt => opt.MapFrom(ent => ent.ProductId))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
