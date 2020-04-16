using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViajesAPI.UnitOfWorks
{
    public interface IUnitOfWorks
    {
        Task SaveChanges();
    }
}
