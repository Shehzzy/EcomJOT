using Ecommerce_JOT.Models;
using Ecommerce_JOT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<IActionResult> ShowProducts()
        {
            List<Product> products = await _dbcontext.Products.Include(p => p.Category).ToListAsync();

            return View(products);
        }

        public async Task<IActionResult> CreateProducts()
        {
          var categories = await _dbcontext.Categories.ToListAsync();
            ProductFormVM productvm = new ProductFormVM
            {
                Categories = new SelectList(categories, "CatID", "Cat_Name")
            };
            return View(productvm);
        }
       

        [HttpPost]
        public async Task<IActionResult> CreateProducts(ProductFormVM productFormVM)
        {
            // Image file upload 2-Sep

            // get directory
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images");
            //create directory
            Directory.CreateDirectory(uploads);

            var filename = productFormVM.ImageFile.FileName;
            var fileupload = Path.Combine(uploads, filename);

            using (var stream = new FileStream(fileupload, FileMode.Create))
            {
                //await productFormVM.ImageFile.CopyToAsync(stream);
                await productFormVM.ImageFile.CopyToAsync(stream);
            }

            productFormVM.Product.ImageName = filename;


           await _dbcontext.Products.AddAsync(productFormVM.Product);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("ShowProducts");
        }

        public async Task< IActionResult> ShowCategories()
        {
            List<Category> categories = await _dbcontext.Categories.ToListAsync();
            return View(categories);
        }



        public IActionResult CreateCategories()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategories(Category category)
        {
           await  _dbcontext.Categories.AddAsync(category);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("ShowCategories");
        }


        public async Task<IActionResult> UpdateCat(int id)
        {
            var cat = await _dbcontext.Categories.FirstOrDefaultAsync(c => c.CatID == id);
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.Category = cat;
            categoryVM.ErrorMessage = "";
            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCat(Category category)
        {
            try
            {
                //Existing entry
                var cat = await _dbcontext.Categories.FirstOrDefaultAsync(c => c.CatID == category.CatID);

                if(cat == null)
                {
                    throw new Exception("Category not found");
                }
                cat.Cat_Name = category.Cat_Name;
                _dbcontext.Categories.Update(cat);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("ShowCategories");
            }

            catch (Exception ex)
            {
                CategoryVM categoryVM = new CategoryVM();
                categoryVM.Category = category;
                categoryVM.ErrorMessage = ex.Message.ToString();
                return View(categoryVM);
            }
           
        }

        public async Task<ActionResult> DeleteCat(int id)
        {
            var cat = await _dbcontext.Categories.FirstOrDefaultAsync(c => c.CatID == id);
            _dbcontext.Categories.Remove(cat);
            await _dbcontext.SaveChangesAsync();
            TempData["Message"] = "Category deleted successfully";
            return RedirectToAction("ShowCategories");
        }




        //[HttpPost]
        //public IActionResult CreateProducts(Product product)
        //{
        //    if(product == null || string.IsNullOrEmpty(product.Name))
        //    {
        //        return RedirectToAction("Error");
        //    }

        //        _dbcontext.products.Add(product);
        //    return View();
        //}


        public IActionResult Error() {
            return View();
            }
    }
}
