using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Entities;
using ViajesAPI.Reponse;
using ViajesAPI.Repositories.Interfaces;
using ViajesAPI.Services.Interfaces;
using ViajesAPI.UnitOfWorks;

namespace ViajesAPI.Services.Implementations
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorks _uniOfWorks;

        public UserService(IUserRepository userRepository, IUnitOfWorks unitOfWorks)
        {
            _userRepository = userRepository;
            _uniOfWorks = unitOfWorks;
        }
        public async Task<BaseResponse<User>> GetAll()
        {
            try
            {
                var users = await _userRepository.GetAll();
                if (users != null)
                {
                    return new BaseResponse<User>(users);
                }
                else
                {
                    return new BaseResponse<User>("No se encontro ningun resultado");
                }

            }
            catch (Exception ex)
            {
                return new BaseResponse<User>(ex.Message);
            }


        }

        public async Task<BaseResponse<User>> GetById(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);
                if (user != null)
                {
                    return new BaseResponse<User>(user);
                }
                else
                {
                    return new BaseResponse<User>($"No se encontro ningun resultado con id {id}");
                }

            }
            catch (Exception ex)
            {
                return new BaseResponse<User>(ex.Message);
            }

        }
        public async Task<BaseResponse<User>> Add(User user)
        {
            try
            {
                await _userRepository.Add(user);
                await _uniOfWorks.SaveChanges();
                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>(ex.Message);
            }

        }
        public async Task<BaseResponse<User>> Delete(User user)
        {

            try
            {
                 _userRepository.Delete(user);
                await _uniOfWorks.SaveChanges();
                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>(ex.Message);
            }
        }
    }
}
