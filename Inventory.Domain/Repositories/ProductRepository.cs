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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MainContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await GetAll().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetPageAsync(int? page, int? size)
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
