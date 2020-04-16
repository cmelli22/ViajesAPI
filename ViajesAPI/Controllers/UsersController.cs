using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajesAPI.Models.Entities;
using ViajesAPI.Services.Implementations;
using ViajesAPI.Services.Interfaces;

namespace ViajesAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// devuelve todos los usuarios con los mensjaes que cada uno mando
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetAll();
            if (!response.status)
            {
                return NotFound(response.message);
            }
            else
            {
                return Ok(response.dataList);
            }
          
        }
        /// <summary>
        /// Busca Usuario en la base de datos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _userService.GetById(id);
            if (response.status == false)
            {
                return NotFound(response.message);
            }
            else
            {
                return Ok(response.data);
            }
  

        }
        /// <summary>
        /// Agrega un usuario a la base de datos
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ingrese un usuario correcto");
            }
            else
            {
                var response = await _userService.Add(user);
                if (!response.status)
                {
                    return NotFound(response.message);
                }
                else
                {
                    return Ok(response.data);
                }
                
            }

        }
        /// <summary>
        /// Elimina un usuario en la base de datos si existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetById(id);
            if(user.data == null)
            {
                return NotFound("No se encontro el usuario que quiere eliminar");
            }
            else
            {
                var response = await _userService.Delete(user.data);
                if (!response.status)
                {
                    return NotFound(response.message);
                }
                else
                {
                    return Ok(response.data);
                }

            }
        }
    }
}