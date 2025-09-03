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

        public int CatID { get; set; }

        public Category? Category { get; set; }
<<<<<<< HEAD

        public string? ImageName { get; set; }
=======
>>>>>>> ffc69165a0c64bc42136f58b300b43f1a04f5e67
    }
}
