using System.Threading.Tasks;
using ViajesAPI.Models.Contexts;

namespace ViajesAPI.UnitOfWorks
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly Context _context;

        public UnitOfWorks(Context context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
