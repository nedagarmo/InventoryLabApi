using Inventory.Domain.Abstractions;
using Inventory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Abstractions
{
    public interface IStockRepository : IRepository<Stock>
    {
        Task<Stock> GetByIdAsync(Guid id);
        Task<Stock> GetByProductAndWarehouseIdAsync(Guid product, Guid warehouse);
        Task<List<Stock>> GetByProductIdAsync(Guid product);
        Task<List<Stock>> GetPageAsync(int? page, int? size);
    }
}
