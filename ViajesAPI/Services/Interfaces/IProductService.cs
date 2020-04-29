using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Entities;
using ViajesAPI.Reponse;

namespace ViajesAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<BaseResponse<Product>> GetAll();
        Task<BaseResponse<Product>> GetById(Guid id);
        Task<BaseResponse<Product>> Add(Product user);
        Task<BaseResponse<Product>> Delete(Product user);
    }
}
