using Inventory.Entities.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Abstractions
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly MainContext DbContext;

        public Repository(MainContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return DbContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudieron obtener los registros: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)}: El objeto no puede ser nulo.");
            }

            try
            {
                await DbContext.AddAsync(entity);
                await DbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} no se pudo guardar: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)}: El objeto no puede ser nulo");
            }

            try
            {
                DbContext.Update(entity);
                await DbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} no se pudo actualizar: {ex.Message}");
            }
        }
    }
}
