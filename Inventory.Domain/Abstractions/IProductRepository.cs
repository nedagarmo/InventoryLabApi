using Inventory.Domain.Abstractions;
using Inventory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Abstractions
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<List<Product>> GetPageAsync(int? page, int? size);
    }
}
