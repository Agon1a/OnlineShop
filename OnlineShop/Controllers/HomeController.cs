using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database;
using OnlineShop.Lib;
using OnlineShop.Models;
using OnlineShop.Models.DBModels;
using System.Diagnostics;

namespace OnlineShop.Controllers
{
    [CustomAuthorizationFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly ApplicationContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            
            return View(categories);
        }

        public IActionResult ShoppingCart()
        {
            List<Product> productsInCart = _context.Products.ToList();
            return View(productsInCart);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
