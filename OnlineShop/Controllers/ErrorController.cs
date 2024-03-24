using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("/Error/HttpStatusCodeHandler")]
        public IActionResult HttpStatusCodeHandler(int? statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("NotFound");
                default:
                    return View("Error");
            }
        }

        [HttpGet("/Error/NotFound")]
        public IActionResult NotFound()
        {
            return View("NotFound");
        }
        public IActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}