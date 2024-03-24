using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineShop.Database;
using OnlineShop.Lib.IO;
using OnlineShop.Models.DBModels;

namespace OnlineShop.Lib
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationContext _context;

        public ShoppingCartService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddToCartAsync(string userId, Guid productId)
        {
            // Проверяем, существует ли корзина для указанного пользователя
            var shoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(sc => sc.UserId == userId);

            if (shoppingCart == null)
            {
                // Если корзина не существует, создаем новую
                shoppingCart = new ShoppingCart
                {
                    UserId = userId,
                    ProductsJson = "[]" // Создаем пустой JSON-массив
                };
                _context.ShoppingCarts.Add(shoppingCart);
            }

            Product currentProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            List<Product> productList;
            // Проверяем, является ли строка пустой или равной "{[]}"
            if (shoppingCart.ProductsJson == "[]" || shoppingCart.ProductsJson == "{[]}")
            {
                // Если да, инициализируем productList пустым списком
                productList = new List<Product>();
            }
            else
            {
                // В противном случае, десериализуем JSON строку
                productList = GetProductsInCart(userId);
            }

            productList.Add(currentProduct);
            shoppingCart.ProductsJson = JsonConvert.SerializeObject(productList);

            await _context.SaveChangesAsync();
        }

        public List<Product> GetProductsInCart(string userId)
        {
            // Находим запись корзины для указанного пользователя
            var shoppingCart = _context.ShoppingCarts
                .FirstOrDefault(c => c.UserId == userId);

            if (shoppingCart.ProductsJson != "[]" && shoppingCart.ProductsJson != "{[]}")
            {
                List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(shoppingCart.ProductsJson);
                return productList;
            }
            else
            {
                // Возвращаем пустой список, если корзина не найдена
                return new List<Product>();
            }
        }

        public async Task RemoveFromCartAsync(string userId, Guid productId)
        {
            // Находим запись корзины для указанного пользователя
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(c => c.UserId == userId);

            if (shoppingCart != null)
            {
                // Извлекаем список товаров из JSON-строки
                var productList = GetProductsInCart(userId);

                // Находим товар в списке и уменьшаем его количество
                var productToRemove = productList.FirstOrDefault(p => p.ProductId == productId);
                productList.Remove(productToRemove);
                // Обновляем JSON-строку
                shoppingCart.ProductsJson = JsonConvert.SerializeObject(productList);

                await _context.SaveChangesAsync();
            }
        }






        public async Task UpdateAsync(string userId, Guid productId)
        {
            // Находим запись в корзине для указанного пользователя и товара
            var cart = await _context.ShoppingCarts
                .FirstOrDefaultAsync(c => c.UserId == userId);

            // Ваша логика обновления записи в корзине
            // Например, добавление товара в корзину

            await _context.SaveChangesAsync(); // Сохраняем изменения в базе данных
        }
    }
}
