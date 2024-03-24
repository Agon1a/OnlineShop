using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        // GET: /Order/Checkout
        public IActionResult Checkout()
        {
            // Здесь можно добавить логику для оформления заказа
            // Например, создание нового заказа в базе данных и перенаправление пользователя на страницу подтверждения заказа
            return RedirectToAction("Confirmation"); // Перенаправляем пользователя на страницу подтверждения заказа
        }

        // GET: /Order/Confirmation
        public IActionResult Confirmation()
        {
            // Здесь можно отобразить страницу с подтверждением заказа
            return View();
        }
    }
}
