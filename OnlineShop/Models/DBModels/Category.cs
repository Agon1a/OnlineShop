using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.DBModels
{
    public class Category
    {
        [Key]
        [Display(Name = "Номер категории")]
        public Guid CategoryId { get; set; }

        [Required]
        [Display(Name = "Название категории")]
        [MinLength(3)]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
