using ViajesAPI.Models.Entities;

namespace ViajesAPI.ViewModels.BodyModels
{
    public class BodyMessage
    {
        public string message { get; set; }
        public bool readed { get; set; } = false;
        public string product { get; set; }

        public User user { get; set; }
    }
}
