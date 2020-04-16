using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Entities;

namespace ViajesAPI.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity:class
  
    {
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        void Delete(TEntity entity);
 
    }
}
