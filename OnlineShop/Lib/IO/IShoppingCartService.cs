using OnlineShop.Models;
using OnlineShop.Models.DBModels;

namespace OnlineShop.Lib.IO
{
    public interface IShoppingCartService
    {
        Task AddToCartAsync(string userId, Guid productId);
        Task RemoveFromCartAsync(string userId, Guid productId);
        List<Product> GetProductsInCart(string userId);
        List<ProductCountViewModel> CountItemsInCart(List<Product> productsInCart);
    }
}
