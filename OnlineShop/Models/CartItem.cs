using OnlineShop.Models.DBModels;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
       
    }
}
