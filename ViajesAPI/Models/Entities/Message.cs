using System.ComponentModel.DataAnnotations;

namespace ViajesAPI.Models.Entities
{
    public class Message
    {
        public int id { get; set; }
        [Required]
        public string message { get; set; }
        public bool readed { get; set; }
        public string product { get; set; }
        public int userId { get; set; }

        public User user { get; set; }
    }
}
