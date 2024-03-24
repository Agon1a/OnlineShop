using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Lib;
using OnlineShop.Lib.IO;

namespace OnlineShop.Controllers
{
    [CustomAuthorizationFilter]
    public class ProductController : Controller
    {
        IProductService _productService;
        readonly ApplicationContext _context;

        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        [CustomAuthorizationFilter]
        public IActionResult Index(Guid productId)
        {
            _productService = new ProductService(_context);
            // Получаем информацию о товаре по его идентификатору productId
            var product = _productService.GetProductById(productId);

            if (product == null)
            {
                // Если товар не найден, возвращаем страницу с сообщением о его отсутствии
                return View("NotFound");
            }

            // Если товар найден, передаем его в представление
            return View(product);
        }

        // GET: /Product/Search
        public IActionResult Search(string productName)
        {
            // Получаем товары, соответствующие критерию поиска
            var products = _context.Products.Where(p => p.ProductName.Contains(productName)).ToList();

            // Передаем найденные товары в представление для отображения
            return View(products);
        }
    }
}
