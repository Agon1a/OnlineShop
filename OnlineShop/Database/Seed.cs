using OnlineShop.Models.DBModels;

namespace OnlineShop.Database
{
    public class Seed
    {
        
        public static async Task TestData(IApplicationBuilder applicationBuilder)
        {
            Constants _constants = new();
            var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
            await SeedCategories(applicationBuilder, _constants, context);
            await SeedProducts(applicationBuilder, _constants, context);
        }
        private static async Task SeedCategories(IApplicationBuilder applicationBuilder, Constants constants, ApplicationContext applicationContext)
        {
            
            if (!applicationContext.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category(constants.fruitsGuid, "Овощи/Фрукты", "https://i.postimg.cc/2jgSVdfg/Fruits.jpg"),
                    new Category(constants.readyGuid, "Готовая еда", "https://i.postimg.cc/B61RyKw1/gotovaya.png"),
                    new Category(constants.seaFoodGuid, "Морепродукты", "https://i.postimg.cc/ryxvN5rB/Sea-food.jpg"),
                    new Category(constants.milkGuid, "Молочные продукты", "https://i.postimg.cc/3wkq4Ghb/Milk.png"),
                    new Category(constants.beveragesGuid, "Напитки", "https://i.postimg.cc/tCDvBkCM/Napitki.jpg"),
                    new Category(constants.meatGuid, "Мясные изделия", "https://i.postimg.cc/VvggHs1C/Meat.jpg"),
                    new Category(constants.candyGuid, "Сладости", "https://i.postimg.cc/xTd312n6/image.jpg"),
                    new Category(constants.bakingGuid, "Выпечка", "https://i.postimg.cc/Y9k1Kcdf/image.jpg"),
                };
                applicationContext.Database.EnsureCreated();

                foreach (var category in categories)
                {
                    applicationContext.Categories.Add(category);
                }

                applicationContext.SaveChanges();
            }    
        }
        private static async Task SeedProducts(IApplicationBuilder applicationBuilder, Constants constants, ApplicationContext applicationContext)
        {
            if (!applicationContext.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product("Банан 1 шт.", "Банан бразильский", 76, "https://i.postimg.cc/s1Fjqzc3/Product.jpg", constants.fruitsGuid),
                    new Product("Говядина вырезка 1 кг.", "Говядина Земная", 590, "https://i.postimg.cc/s1Fjqzc3/Product.jpg", constants.meatGuid),
                    new Product("Яки нику", "Очень вкусно", 290, "https://i.postimg.cc/s1Fjqzc3/Product.jpg", constants.readyGuid),
                    new Product("Креветки северные 1 кг.", "'Креветки северные, мертвые", 600, "https://i.postimg.cc/s1Fjqzc3/Product.jpg", constants.seaFoodGuid),
                    new Product("Торт Наполенон 1 кг.", "Торт вкусный, сам ел", 726, "https://i.postimg.cc/s1Fjqzc3/Product.jpg", constants.candyGuid),
                    new Product("Молоко 1 л.", "Молоко деревенское", 76, "https://i.postimg.cc/s1Fjqzc3/Product.jpg", constants.milkGuid),
                    new Product("Пирожок с капустой 1 шт.", "Пирожок бабушкин", 76, "https://i.postimg.cc/s1Fjqzc3/Product.jpg", constants.bakingGuid),
                    new Product("Сок яблочный 1 л.", "Кислый", 90, "https://i.postimg.cc/s1Fjqzc3/Product.jpg", constants.beveragesGuid),

                };
                applicationContext.Database.EnsureCreated();

                foreach (var product in products)
                {
                    applicationContext.Products.Add(product);
                }

                applicationContext.SaveChanges();
            }
        }
        
    }
    class Constants
    {
        public Guid fruitsGuid;
        public Guid readyGuid;
        public Guid seaFoodGuid;
        public Guid milkGuid;
        public Guid beveragesGuid;
        public Guid meatGuid;
        public Guid candyGuid;
        public Guid bakingGuid;

        public Constants()
        {
            fruitsGuid = Guid.NewGuid();
            readyGuid = Guid.NewGuid();
            seaFoodGuid = Guid.NewGuid();
            milkGuid = Guid.NewGuid();
            beveragesGuid = Guid.NewGuid();
            meatGuid = Guid.NewGuid();
            candyGuid = Guid.NewGuid();
            bakingGuid = Guid.NewGuid();
        }
    }
}
