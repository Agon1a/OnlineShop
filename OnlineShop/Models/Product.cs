using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Display(Name = "Название товара")]
        [MinLength(3)]
        [MaxLength(120)]
        public string ProductName { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Display(Name = "Цена")]
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [Column(TypeName = "varbinary(MAX)")]
        public byte[] Image { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
