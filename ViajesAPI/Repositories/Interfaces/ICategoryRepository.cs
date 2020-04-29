using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Entities;

namespace ViajesAPI.Repositories.Interfaces
{
    interface ICategoryRepository : IGenericRepository<Category,int>
    {
    }
}
