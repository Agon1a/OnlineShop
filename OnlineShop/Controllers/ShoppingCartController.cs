using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Lib;
using OnlineShop.Lib.IO;
using OnlineShop.Models.DBModels;
using System.Security.Claims;

namespace OnlineShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ApplicationContext _context;

        public ShoppingCartController(ApplicationContext context, IShoppingCartService shoppingCartService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId)
        {
            // Получаем идентификатор пользователя (ваш способ может отличаться)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Добавляем товар в корзину
            await _shoppingCartService.AddToCartAsync(userId, productId);

            return View();
        }
    }
}
