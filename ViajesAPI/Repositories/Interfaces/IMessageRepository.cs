using System;
using ViajesAPI.Models.Entities;

namespace ViajesAPI.Repositories.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message,int>
    {
    }
}
