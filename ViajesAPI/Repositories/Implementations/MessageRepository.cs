using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Contexts;
using ViajesAPI.Models.Entities;
using ViajesAPI.Repositories.Interfaces;
using ViajesAPI.ViewModels.BodyModels;

namespace ViajesAPI.Repositories.Implementations
{
    public class MessageRepository: GenericRepository<Message>, IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context):base(context)
        {
            _context = context;
        }
        public override async Task<IList<Message>> GetAll()
        {
            return await _context.meesages.ToListAsync();
        }

        public override async Task<Message> GetById(int id)
        {
            return await _context.meesages.Include(m => m.user).FirstOrDefaultAsync(d => d.id == id);
        }

    }
}
