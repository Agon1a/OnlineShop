using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.AccountModels
{
    public class LoginViewModel
    {
        [Display(Name = "Адрес электронной почты")]
        [Required(ErrorMessage = "Введите адрес почты")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
