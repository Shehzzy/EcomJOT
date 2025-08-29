using Ecommerce_JOT.Models;
using Ecommerce_JOT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult ShowProducts()
        {

            return View();
        }

        public IActionResult CreateProducts()
        {
          
            return View();
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

        [HttpDelete]
        public async Task<IActionResult> DeleteCat(int id)
        {
            var cat = await _dbcontext.Categories.FirstOrDefaultAsync(c => c.CatID == id);
            if( cat == null)
            {
                throw new Exception("Category not found");
            }
            _dbcontext.Categories.Remove(cat);
            await _dbcontext.SaveChangesAsync();
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
