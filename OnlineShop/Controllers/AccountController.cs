using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Lib;
using OnlineShop.Models.AccountModels;
using OnlineShop.Models.DBModels;
using System.Security.Claims;

namespace OnlineShop.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        private readonly ApplicationContext _context;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<AccountController> logger,
            ApplicationContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = dbContext;
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
                    _context.ShoppingCarts.Add(shoppingCart);
                    await _context.SaveChangesAsync();
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

        [HttpGet]
        [CustomAuthorizationFilter]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [CustomAuthorizationFilter]
        public async Task<IActionResult> SaveProfile(string Fullname, string Email, string PhoneNumber)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var existingUser = await _context.Users.FindAsync(currentUser.Id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.Fullname = Fullname;
                existingUser.Email = Email;
                existingUser.PhoneNumber = PhoneNumber;

                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("UserDashboard");
        }

        [CustomAuthorizationFilter]
        public IActionResult Addresses()
        {
            // Получаем идентификатор пользователя
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userAddresses = _context.UserAddresses.Where(p => p.UserId == userId).ToList();

            return View(userAddresses);
        }

        [CustomAuthorizationFilter]
        public IActionResult Orders()
        {
            // Получаем идентификатор пользователя
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orders = _context.Orders.Where(o => o.UserId == userId).ToList();

            return View(orders);
        }

        [HttpPost]
        public IActionResult AddAddress(string addressName, string street, string? house, string? flat, string? entrance, string? floor)
        {
            if (ModelState.IsValid)
            {
                // Получаем идентификатор пользователя
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                var newAddress = new UserAddress
                {
                    AddressName = addressName,
                    UserId = userId,
                    Street = street,
                    House = house,
                    Flat = flat,
                    Entrance = entrance,
                    Floor = floor
                };

                // Добавление адреса в контекст базы данных
                _context.UserAddresses.Add(newAddress);
                _context.SaveChanges();

                return RedirectToAction("UserDashboard"); 
            }

            return RedirectToAction("UserDashboard");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAddress(Guid addressId)
        {
            // Получаем идентификатор пользователя (ваш способ может отличаться)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Удаляем товар из корзины
            var userAddress = await _context.UserAddresses.FindAsync(addressId);
            _context.UserAddresses.Remove(userAddress);
            await _context.SaveChangesAsync();

            return RedirectToAction("Addresses");
        }

        [CustomAuthorizationFilter]
        public async Task<IActionResult> UserDashboard()
        {
            var user = await _userManager.GetUserAsync(User);
            var userAddresses = _context.UserAddresses.Where(a => a.UserId == user.Id).ToList();
            var orders = _context.Orders.Where(o => o.UserId == user.Id).ToList();

            ViewData["User"] = user;
            ViewData["UserAddresses"] = userAddresses;
            ViewData["Orders"] = orders;

            return View();
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
