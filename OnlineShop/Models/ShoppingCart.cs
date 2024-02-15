using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class ShoppingCart
    {
        [Key]
        public Guid CartId { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string ProductsJson { get; set; }
        public List<Product> Products { get; set; }

        // Добавить метода конвертации [ProductsJson] в экземпляры класса Product и занесения в List ShoppingCart.Products
    }
}
