using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class UserAddress
    {
        [Key]
        public Guid AddressId { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Display(Name = "Название адреса")]
        [MaxLength(50)]
        public string AddressName { get; set; }

        [Display(Name = "Улица")]
        [MaxLength(50)]
        public string Street { get; set; }

        [Display(Name = "Дом")]
        [MaxLength(50)]
        public string? House { get; set; }

        [Display(Name = "Квартира")]
        [MaxLength(50)]
        public string? Flat { get; set; }

        [Display(Name = "Подъезд")]
        [MaxLength(50)]
        public string? Entrance { get; set; }

        [Display(Name = "Этаж")]
        [MaxLength(50)]
        public string? Floor { get; set; }
    }
}
