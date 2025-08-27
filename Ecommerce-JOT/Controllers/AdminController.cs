using Ecommerce_JOT.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_JOT.Controllers
{
    public class AdminController : Controller
    {
        public readonly AppDbContext _dbcontext;
        public AdminController(AppDbContext context)
        {
            _dbcontext = context;
        }


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {
          
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(product == null || string.IsNullOrEmpty(product.Name))
            {
                return RedirectToAction("Error");
            }

                _dbcontext.products.Add(product);
            return View();
        }


        public IActionResult Error() {
            return View();
            }
    }
}
