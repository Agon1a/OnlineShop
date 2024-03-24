using OnlineShop.Models.DBModels;

namespace OnlineShop.Lib.IO
{
    public interface IShoppingCartService
    {
        Task AddToCartAsync(string userId, Guid productId);
        Task RemoveFromCartAsync(string userId, Guid productId);
        Task <List<Product>?> GetProductsInCart(string userId);
    }
}
