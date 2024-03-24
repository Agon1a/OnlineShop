using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class ShopingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
