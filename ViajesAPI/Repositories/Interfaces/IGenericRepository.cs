using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViajesAPI.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity,T>
        where TEntity : class
        where T:struct

    {
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(T id);
        Task Add(TEntity entity);
        void Delete(TEntity entity);
        
    }
}
