using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class User : IdentityUser
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Бонусы")]
        public int Bonuses { get; set; }
    }
}
