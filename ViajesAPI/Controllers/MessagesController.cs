using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViajesAPI.Models.Entities;
using ViajesAPI.Repositories.Interfaces;
using ViajesAPI.Services.Interfaces;

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
        /// Busca un Mensaje por id
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
                if (response.data != null)
                {
                    return Ok(response.data);
                }
                else
                {
                    return NotFound("No se encontro ningun mensaje");
                }
            }
        }
        /// <summary>
        /// Agrega un mensaje. si el usuario no existe en la Base de datos lo agrega
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
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
                return Ok(response.message);
            }

        }
    }
}