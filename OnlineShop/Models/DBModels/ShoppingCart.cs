using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models.DBModels
{
    public class ShoppingCart
    {
        [Key]
        public Guid CartId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        public string ProductsJson { get; set; }

        // Добавить метода конвертации [ProductsJson] в экземпляры класса Product и занесения в List ShoppingCart.Products
    }
}
