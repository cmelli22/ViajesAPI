using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViajesAPI.Models.Entities
{
    public class User
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string lastName { get; set; }
        [MaxLength(30)]
        public string telefono { get; set; }
        [Required]
        [MaxLength(100)]
        public string email { get; set; }

        public IList<Message> messages { get; set; } = new List<Message>();

    }
}
