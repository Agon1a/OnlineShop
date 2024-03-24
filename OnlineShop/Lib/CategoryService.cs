using Microsoft.EntityFrameworkCore;
using OnlineShop.Database;
using OnlineShop.Lib.IO;
using OnlineShop.Models.DBModels;

namespace OnlineShop.Lib
{
    public class CategoryService :ICategoryService
    {
        private readonly ApplicationContext _context;

        public CategoryService(ApplicationContext context)
        {
            _context = context;
        }

        public string GetCategoryName(Guid categoryId)
        {
            return _context.Categories
                .Where(c => c.CategoryId == categoryId)
                .Select(c => c.CategoryName)
                .FirstOrDefault();
        }

        public List<Product> GetProductsByCategory(Guid categoryId)
        {
            var products = _context.Products.Where(p => p.CategoryId == categoryId).ToList();
            return products;
        }
    }
}
