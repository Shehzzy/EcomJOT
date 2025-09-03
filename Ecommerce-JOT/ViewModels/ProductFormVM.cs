using Ecommerce_JOT.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce_JOT.ViewModels
{
    public class ProductFormVM
    {
        public Product Product { get; set; }

        public SelectList Categories { get; set; }
<<<<<<< HEAD

        public IFormFile ImageFile { get; set; }
=======
>>>>>>> ffc69165a0c64bc42136f58b300b43f1a04f5e67
    }
}
