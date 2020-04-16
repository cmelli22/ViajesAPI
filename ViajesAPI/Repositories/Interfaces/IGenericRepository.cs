using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViajesAPI.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class

    {
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        void Delete(TEntity entity);

    }
}
