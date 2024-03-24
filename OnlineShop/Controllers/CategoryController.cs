using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Lib;
using OnlineShop.Lib.IO;

namespace OnlineShop.Controllers
{
    [CustomAuthorizationFilter]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        readonly ApplicationContext _context;
        public CategoryController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index(Guid CategoryId)
        {
            _categoryService = new CategoryService(_context);
            // Ваша логика поиска товаров по категории
            var products = _categoryService.GetProductsByCategory(CategoryId); // Метод для получения товаров по категории

            ViewBag.CategoryName = _categoryService.GetCategoryName(CategoryId);

            return View(products);
        }
    }
}
