using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShop.Database;
using OnlineShop.Lib;
using OnlineShop.Lib.IO;
using OnlineShop.Models.DBModels;
using System.Security.Claims;

namespace OnlineShop.Controllers
{
    [CustomAuthorizationFilter]
    public class OrderController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ApplicationContext _context;

        public OrderController(IShoppingCartService shoppingCartService, ApplicationContext context)
        {
            _shoppingCartService = shoppingCartService;
            _context = context;
        }

        public IActionResult Checkout()
        {
            // Получение значений из объекта Request.Form
            var fullName = Request.Form["fullName"];
            var phoneNumber = Request.Form["phoneNumber"];
            var addressName = Request.Form["addressName"];
            var paymentMethod = Request.Form["paymentMethod"];

            // Проверка на пустые значения параметров
            if (string.IsNullOrWhiteSpace(fullName))
            {
                ModelState.AddModelError("fullName", "Пожалуйста, введите ФИО.");
            }
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                ModelState.AddModelError("phoneNumber", "Пожалуйста, введите номер телефона.");
            }
            if (string.IsNullOrWhiteSpace(addressName))
            {
                ModelState.AddModelError("addressName", "Пожалуйста, выберите адрес.");
            }

            // Проверка на наличие ошибок в модели
            if (!ModelState.IsValid)
            {
                // Если есть ошибки, возвращаем представление с сообщением об ошибке
                return View("Error");
            }

            // Получаем идентификатор пользователя
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userData = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

            // Получаем товары в корзине для текущего пользователя
            var productsInCart = _shoppingCartService.GetProductsInCart(userId);

            // Подсчитываем количество каждого товара в корзине
            var itemCounts = _shoppingCartService.CountItemsInCart(productsInCart);
            var totalCost = itemCounts.Select(p => p.TotalCost).Sum();


            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.UserId == userId);

            // Создаем новый заказ
            var order = new Order
            {
                UserId = userId,
                TotalPrice = totalCost,
                ProductsJson = JsonConvert.SerializeObject(productsInCart),
                OrderDate = DateOnly.FromDateTime(DateTime.Today)  // Используем текущую дату без времени
            };

            // Добавляем заказ в контекст данных
            _context.Orders.Add(order);

            shoppingCart.ProductsJson = "{[]}";
            userData.Bonuses = (int)(totalCost / 100 * 10); // 10% от заказа
            _context.SaveChanges();

            return RedirectToAction("Index", "Home"); // Перенаправляем пользователя на страницу подтверждения заказа
        }


        public IActionResult Confirmation()
        {
            // Получаем идентификатор пользователя
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userData = _context.Users.Where(u=> u.Id == userId).FirstOrDefault();

            // Получаем товары в корзине для текущего пользователя
            var productsInCart = _shoppingCartService.GetProductsInCart(userId);

            // Подсчитываем количество каждого товара в корзине
            var itemCounts = _shoppingCartService.CountItemsInCart(productsInCart);

            if (itemCounts.Count == 0)
            {
                // Если корзина пуста, выполняем перенаправление на главную страницу
                return RedirectToAction("Index", "Home");
            }
            var totalCost = itemCounts.Select(p => p.TotalCost).Sum();

            // Передаем список товаров и количество каждого товара в ViewData
            ViewBag.ItemCounts = itemCounts;
            ViewBag.TotalCost = totalCost;

            // Получаем данные UserAddresses из базы данных или любого другого источника
            var userAddresses = _context.UserAddresses.ToList();

            // Создаем новый список, содержащий только AddressName
            var addressNames = userAddresses.Where(address => address.UserId == userId).Select(address => address.AddressName).ToList();

            // Передаем данные UserAddresses в представление через ViewBag
            ViewBag.UserAddresses = addressNames;

            ViewBag.User = userData;

            return View();
        }
    }
}
