using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Lib;
using OnlineShop.Lib.IO;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        readonly ApplicationContext _context;

        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

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
    }
}
