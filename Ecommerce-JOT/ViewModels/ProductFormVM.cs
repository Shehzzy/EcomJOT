using Ecommerce_JOT.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce_JOT.ViewModels
{
    public class ProductFormVM
    {
        public Product Product { get; set; }

        public SelectList Categories { get; set; }

        public IFormFile ImageFile { get; set; }

        public string ErrorMessage  { get; set; }
    }
}
