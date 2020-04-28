using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViajesAPI.Models.Entities
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        [InverseProperty("category")]
        public List<Product> products { get; set; } = new List<Product>();
    }
}
