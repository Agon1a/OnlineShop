﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models.DBModels
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
        public string ImageUrl { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string productName, string? description, decimal cost, string imageUrl, Guid categoryId)
        {
            ProductId = new Guid();
            ProductName = productName;
            Description = description;
            Cost = cost;
            ImageUrl = imageUrl;
            CategoryId = categoryId;
        }
    }
}
