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
    public class ListMapperProfile : Profile
    {
        public ListMapperProfile()
        {
            CreateMap<Warehouse, WarehouseListDTO>();
        }
    }
}
