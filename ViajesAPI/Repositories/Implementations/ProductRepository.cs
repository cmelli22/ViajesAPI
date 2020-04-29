using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Contexts;
using ViajesAPI.Models.Entities;
using ViajesAPI.Repositories.Interfaces;

namespace ViajesAPI.Repositories.Implementations
{
    public class ProductRepository: GenericRepository<Product> , IProdcutRepository
    {
      
        public ProductRepository(Context context) : base(context) { }
    }
}
