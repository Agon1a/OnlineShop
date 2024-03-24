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

        // Метод для отображения корзины
        public IActionResult Index()
        {
            // Получаем идентификатор пользователя (ваш способ может отличаться)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Получаем товары в корзине для текущего пользователя
            var productsInCart = _shoppingCartService.GetProductsInCart(userId);

            return View(productsInCart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId)
        {
            // Получаем идентификатор пользователя (ваш способ может отличаться)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Получаем идентификатор пользователя (ваш способ может отличаться)
            var userData = _context.Users.FirstOrDefault(u => u.Id == userId);

            // Добавляем товар в корзину
            await _shoppingCartService.AddToCartAsync(userId, productId);

            return View();
        }

        // Метод для удаления товара из корзины
        [HttpPost]
        public IActionResult RemoveFromCart(Guid productId)
        {
            // Получаем идентификатор пользователя (ваш способ может отличаться)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Удаляем товар из корзины
            _shoppingCartService.RemoveFromCartAsync(userId, productId);

            // Перенаправляем пользователя обратно на страницу корзины
            return RedirectToAction("Index");
        }
    }
}
