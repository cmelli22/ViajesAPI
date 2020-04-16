using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Entities;

namespace ViajesAPI.ViewModels
{
    public class MessageViewModel: BaseEntity
    {
        public string message { get; set; }
        public bool readed { get; set; }
        public string product { get; set; }
        public int userId { get; set; }
 
    }
}
