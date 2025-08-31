using System.ComponentModel.DataAnnotations;

namespace Ecommerce_JOT.Models
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }

        public string? Cat_Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
