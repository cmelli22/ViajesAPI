using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViajesAPI.Models.Entities
{
    public class Product
    {
        public Guid productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double Precio { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category category { get; set; }
        public List<Message> messages { get; set; }
    }
}
