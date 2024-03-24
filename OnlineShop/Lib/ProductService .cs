using OnlineShop.Database;
using OnlineShop.Lib.IO;
using OnlineShop.Models.DBModels;

namespace OnlineShop.Lib
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext _context;

        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public Product GetProductById(Guid productId)
        {
            // Поиск товара по его идентификатору в базе данных
            return _context.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        
    }
}
