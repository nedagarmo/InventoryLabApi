using Inventory.Domain.Abstractions;
using Inventory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Abstractions
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        Task<Warehouse> GetByIdAsync(Guid id);
        Task<List<Warehouse>> GetPageAsync(int? page, int? size);
    }
}
