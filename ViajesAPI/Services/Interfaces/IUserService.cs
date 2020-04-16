using System.Threading.Tasks;
using ViajesAPI.Models.Entities;
using ViajesAPI.Reponse;

namespace ViajesAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<User>> GetAll();
        Task<BaseResponse<User>> GetById(int id);
        Task<BaseResponse<User>> Add(User user);
        Task<BaseResponse<User>> Delete(User user);


    }
}
