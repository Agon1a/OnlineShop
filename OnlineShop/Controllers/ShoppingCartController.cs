using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Lib;
using OnlineShop.Lib.IO;
using System.Security.Claims;

namespace OnlineShop.Controllers
{
    [CustomAuthorizationFilter]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ApplicationContext _context;

        public ShoppingCartController(ApplicationContext context, IShoppingCartService shoppingCartService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> Index()
        {
            // Получаем идентификатор пользователя
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Получаем товары в корзине для текущего пользователя
            var productsInCart = _shoppingCartService.GetProductsInCart(userId);

            // Подсчитываем количество каждого товара в корзине
            var itemCounts = _shoppingCartService.CountItemsInCart(productsInCart);

            // Передаем список товаров и количество каждого товара в ViewData
            ViewBag.ItemCounts = itemCounts;

            return View();
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

        /// <summary>
        /// Добавление товара внутри корзины
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddInCart(Guid productId)
        {
            // Получаем идентификатор пользователя
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userData = _context.Users.FirstOrDefault(u => u.Id == userId);

            // Добавляем товар в корзину
            await _shoppingCartService.AddToCartAsync(userId, productId);

            // Перенаправляем пользователя обратно на страницу корзины
            return RedirectToAction("Index");
        }

        // Метод для удаления товара из корзины
        [HttpPost]
        public IActionResult RemoveFromCart(Guid productId)
        {
            // Получаем идентификатор пользователя
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Удаляем товар из корзины
            _shoppingCartService.RemoveFromCartAsync(userId, productId);

            // Перенаправляем пользователя обратно на страницу корзины
            return RedirectToAction("Index");
        }


    }
}
