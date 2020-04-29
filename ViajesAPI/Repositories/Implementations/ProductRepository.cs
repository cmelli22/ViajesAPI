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
    public class ProductRepository : GenericRepository<Product, Guid>, IProdcutRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context) : base(context) 
        {
            _context = context;
        }

        public override async Task<IList<Product>> GetAll()
        {
            return await _context.products.Include(c => c.category).Include(m=> m.messages).ToListAsync();

        }

        public override async Task<Product> GetById(Guid id)
        {
            return await _context.products.Include(c => c.category).Include(m => m.messages).FirstOrDefaultAsync(p => p.productId == id);
        }

    }
}
