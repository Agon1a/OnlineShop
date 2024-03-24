using OnlineShop.Models.DBModels;

namespace OnlineShop.Lib.IO
{
    public interface IProductService
    {
        public Product GetProductById(Guid productId);
    }
}
