using Microsoft.EntityFrameworkCore;
using OnlineShop.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Categories
    {
        [Key]
        
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}
