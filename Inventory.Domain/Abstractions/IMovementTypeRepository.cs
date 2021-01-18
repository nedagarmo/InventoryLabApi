using Inventory.Domain.Abstractions;
using Inventory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Abstractions
{
    public interface IMovementTypeRepository : IRepository<MovementType>
    {
        Task<MovementType> GetByIdAsync(Guid id);
    }
}
