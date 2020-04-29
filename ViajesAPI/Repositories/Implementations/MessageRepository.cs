using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViajesAPI.Models.Contexts;
using ViajesAPI.Models.Entities;
using ViajesAPI.Repositories.Interfaces;

namespace ViajesAPI.Repositories.Implementations
{
    public class MessageRepository : GenericRepository<Message,int>, IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context) : base(context)
        {
            _context = context;
        }
        public override async Task<IList<Message>> GetAll()
        {
            return await _context.meesages.ToListAsync();
        }

        public override async Task<Message> GetById( int id)
        {
            return await _context.meesages.Include(m => m.user).FirstOrDefaultAsync(d => d.id == id);
        }

    }
}
