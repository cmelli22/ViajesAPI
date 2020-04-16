using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViajesAPI.Models.Entities
{
    public class Message 
    {
        public int id { get; set; }
        public string message { get; set; }
        public bool readed { get; set; }
        public string product { get; set; }
        public int userId { get; set; }
      
        public User user { get; set; }
    }
}
