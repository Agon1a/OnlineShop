using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.DBModels
{
    public class User : IdentityUser
    {

        [Display(Name = "Бонусы")]
        public int Bonuses { get; set; }
    }
}
