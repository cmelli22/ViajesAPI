using System.Threading.Tasks;

namespace ViajesAPI.UnitOfWorks
{
    public interface IUnitOfWorks
    {
        Task SaveChanges();
    }
}
