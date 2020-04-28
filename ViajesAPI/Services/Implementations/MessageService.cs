using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Entities;
using ViajesAPI.Reponse;
using ViajesAPI.Repositories.Interfaces;
using ViajesAPI.Services.Interfaces;
using ViajesAPI.UnitOfWorks;
using ViajesAPI.ViewModels;

namespace ViajesAPI.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IUserService _userService;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _unitOfWorks;

        public MessageService(IMessageRepository messageRepository,
            IMapper mapper, IUserService userService, IUnitOfWorks unitOfWorks)
        {
            _messageRepository = messageRepository;
            _userService = userService;
            _mapper = mapper;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<BaseResponse<MessageViewModel>> GetAll()
        {
            try
            {
                var messages = await _messageRepository.GetAll();
                var messageViewModel = _mapper.Map<IList<Message>, IList<MessageViewModel>>(messages);
                return new BaseResponse<MessageViewModel>(messageViewModel);

            }
            catch (Exception ex)
            {
                return new BaseResponse<MessageViewModel>(ex.Message);
            }

        }

        public async Task<BaseResponse<MessageViewModel>> GetById(int id)
        {
            try
            {
                var message = await _messageRepository.GetById(id);
                var messageViewModel = _mapper.Map<Message, MessageViewModel>(message);
                return new BaseResponse<MessageViewModel>(messageViewModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse<MessageViewModel>(ex.Message);
            }
        }

        public async Task<BaseResponse<MessageViewModel>> AddMessage(Message message)
        {
            #region ExisteUsuario

            User UsuarioExistente = null;
            var response = await _userService.GetAll();
            var users = response.dataList;

            foreach (var u in users)
            {
                if (u.email == message.user.email)
                {
                    UsuarioExistente = u;

                }
            }
            #endregion
            
            if (UsuarioExistente == null)
            {

                try
                {
                    await _userService.Add(message.user);
                    var usuarios = await _userService.GetAll();
                    message.user = usuarios.dataList.Last();

                }
                catch (Exception ex)
                {
                    return new BaseResponse<MessageViewModel>(ex.Message);
                }
            }
            else
            {
                message.user = UsuarioExistente;    
            }

            try
            {
                var messageViewModel = _mapper.Map<Message, MessageViewModel>(message);
                await _messageRepository.Add(message);
                await _unitOfWorks.SaveChanges();
                return new BaseResponse<MessageViewModel>(messageViewModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse<MessageViewModel>(ex.Message);
            }






        }

        public async Task<BaseResponse<MessageViewModel>> DeleteMessage(MessageViewModel message)
        {
            return new BaseResponse<MessageViewModel>("sarasa");
        }
    }
}
