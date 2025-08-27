using System.ComponentModel.DataAnnotations;

namespace Ecommerce_JOT.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }


        public string? Name { get; set; }

        public string? description { get; set; }

        public int price { get; set; }

        public int qty { get; set; }
    }
}
