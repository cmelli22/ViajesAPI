using System.Threading.Tasks;
using ViajesAPI.Models.Entities;
using ViajesAPI.Reponse;
using ViajesAPI.ViewModels;

namespace ViajesAPI.Services.Interfaces
{
    public interface IMessageService
    {
        Task<BaseResponse<MessageViewModel>> GetAll();
        Task<BaseResponse<MessageViewModel>> GetById(int id);
        Task<BaseResponse<MessageViewModel>> AddMessage(Message message);
        Task<BaseResponse<MessageViewModel>> DeleteMessage(MessageViewModel message);
    }
}
