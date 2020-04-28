using System;

namespace ViajesAPI.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string message { get; set; }
        public bool readed { get; set; }
        public Guid productId { get; set; }
        public int userId { get; set; }

    }
}
