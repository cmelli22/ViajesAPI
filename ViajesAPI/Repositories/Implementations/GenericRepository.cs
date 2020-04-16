using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Contexts;
using ViajesAPI.Models.Entities;
using ViajesAPI.Repositories.Interfaces;

namespace ViajesAPI.Repositories.Implementations
{
    public abstract class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity:class
    
    {
        private readonly Context _context;
        private DbSet<TEntity> entities;

        public GenericRepository(Context context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }

        public virtual async Task<IList<TEntity>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await entities.FirstOrDefaultAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            await entities.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            entities.Remove(entity);
        }
    }
}
