using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViajesAPI.Models.Contexts;
using ViajesAPI.Models.Entities;
using ViajesAPI.Repositories.Interfaces;

namespace ViajesAPI.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        private readonly Context _context;
        public UserRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<IList<User>> GetAll()
        {
            return await _context.users.Include(u => u.messages).ToListAsync();

        }

        public override async Task<User> GetById(int id)
        {
            return await _context.users.Include(u => u.messages).FirstOrDefaultAsync(d => d.id == id);
        }
    }
}
