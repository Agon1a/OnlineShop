using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "ID заказа")]
        public Guid OrderId { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Display(Name = "Дата заказа")]
        public DateOnly OrderDate { get; set; }

        [Display(Name = "Итоговая стоимость")]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public string ProductsJson { get; set; }
        public List<Product> Products { get; set; }


        // Добавить метода конвертации [ProductsJson] в экземпляры класса Product и занесения в List Order.Products
    }
}
