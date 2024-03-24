using OnlineShop.Models.DBModels;

namespace OnlineShop.Lib.IO
{
    public interface ICategoryService
    {
        public List<Product> GetProductsByCategory(Guid categoryId);
        public string GetCategoryName(Guid categoryId);
    }
}
