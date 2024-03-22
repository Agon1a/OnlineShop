using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Models.AccountModels;
using OnlineShop.Models.DBModels;

namespace OnlineShop.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        private readonly ApplicationContext _dbContext;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<AccountController> logger,
            ApplicationContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        [AllowAnonymous]
        
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    // Создание записи в ShoppingCart
                    var shoppingCart = new ShoppingCart { UserId = user.Id };
                    _dbContext.ShoppingCarts.Add(shoppingCart);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        [AllowAnonymous]
        
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Username should be UserName property of User
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    await _signInManager.SignInAsync(user, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неверная попытка входа.");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
