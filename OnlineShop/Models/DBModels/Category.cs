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
        public string ImageUrl { get; set; }


        public Category(Guid categoryId, string categoryName, string imageUrl)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            ImageUrl = imageUrl;
        }
    }
}
