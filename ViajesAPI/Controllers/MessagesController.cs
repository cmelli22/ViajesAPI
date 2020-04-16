using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajesAPI.Models.Entities;
using ViajesAPI.Repositories.Interfaces;
using ViajesAPI.Services.Interfaces;
using ViajesAPI.ViewModels;
using ViajesAPI.ViewModels.BodyModels;

namespace ViajesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageService messageService, IMessageRepository messageRepository)
        {
            _messageService = messageService;
            _messageRepository = messageRepository;
        }
        /// <summary>
        /// Devuelve todos los mensajes de la base de datos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var response = await _messageService.GetAll();
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var response = await _messageService.GetById(id);
            if (!response.status)
            {
                return NotFound(response.message);
            }
            else
            {
                if(response.data != null)
                {
                    return Ok(response.data);
                }
                else
                {
                    return NotFound("No se encontro ningun mensaje");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMeesage([FromBody] Message message)
        {

          
            var response = await _messageService.AddMessage(message);
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