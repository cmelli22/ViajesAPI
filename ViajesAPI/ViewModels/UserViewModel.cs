using System.ComponentModel.DataAnnotations;

namespace ViajesAPI.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string lastName { get; set; }
        [MaxLength(30)]
        public string telefono { get; set; }
        [Required]
        [MaxLength(100)]
        public string email { get; set; }

    }
}
