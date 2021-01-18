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
    public class MovementTypeRepository : Repository<MovementType>, IMovementTypeRepository
    {
        public MovementTypeRepository(MainContext dbContext) : base(dbContext)
        {
        }

        public async Task<MovementType> GetByIdAsync(Guid id)
        {
            return await GetAll().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
