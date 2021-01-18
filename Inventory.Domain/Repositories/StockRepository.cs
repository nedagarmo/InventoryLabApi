using Inventory.Domain.Abstractions;
using Inventory.Entities.Contexts;
using Inventory.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(MainContext dbContext) : base(dbContext)
        {
        }

        public async Task<Stock> GetByIdAsync(Guid id)
        {
            return await GetAll().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Stock> GetByProductAndWarehouseIdAsync(Guid product, Guid warehouse)
        {
            return await GetAll().FirstOrDefaultAsync(p => p.ProductId == product && p.WarehouseId == warehouse);
        }

        public async Task<List<Stock>> GetByProductIdAsync(Guid product)
        {
            return await GetAll().Where(w => w.ProductId == product).ToListAsync();
        }

        public async Task<List<Stock>> GetPageAsync(int? page, int? size)
        {
            /*
             * Definimos un límite máximo de consulta de registros para evitar
             * desbordar la memoria cuando haya una gran cantidad de productos
             * guardados en la base de datos.
             */
            page ??= 0;
            size ??= 10;

            size = size > 100 ? 100 : size;
            return await GetAll().Skip(page.Value).Take(size.Value).ToListAsync();
        }
    }
}
