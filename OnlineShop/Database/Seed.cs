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
                    new Category(constants.fruitsGuid, "Овощи/Фрукты", "https://disk.yandex.ru/i/krBsHxCbI1h1qw"),
                    new Category(constants.readyGuid, "Готовая еда", "https://disk.yandex.ru/i/PRt4mGgu9zEc0Q"),
                    new Category(constants.seaFoodGuid, "Морепродукты", "https://disk.yandex.ru/i/l9mYRqcL22lU7w"),
                    new Category(constants.milkGuid, "Молочные продукты", "https://disk.yandex.ru/i/-lHThJFbWQDhqw"),
                    new Category(constants.beveragesGuid, "Напитки", "https://disk.yandex.ru/i/kuZ6xIz04tr9Ng"),
                    new Category(constants.meatGuid, "Мясные изделия", "https://disk.yandex.ru/i/ZZxlGpHbOUYkqw"),
                    new Category(constants.candyGuid, "Сладости", "https://disk.yandex.ru/i/OYB5fAm3YQpQHg"),
                    new Category(constants.bakingGuid, "Выпечка", "https://disk.yandex.ru/i/sXln-auLH3poQw"),
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
                    new Product("Банан 1 шт.", "Банан бразильский", 76, "https://disk.yandex.ru/i/Yq6WlkDqzZ-gZw", constants.fruitsGuid),
                    new Product("Говядина вырезка 1 кг.", "Говядина Земная", 590, "https://disk.yandex.ru/i/Yq6WlkDqzZ-gZw", constants.meatGuid),
                    new Product("Яки нику", "Очень вкусно", 290, "https://disk.yandex.ru/i/Yq6WlkDqzZ-gZw", constants.readyGuid),
                    new Product("Креветки северные 1 кг.", "'Креветки северные, мертвые", 600, "https://disk.yandex.ru/i/Yq6WlkDqzZ-gZw", constants.fruitsGuid),
                    new Product("Торт Наполенон 1 кг.", "Торт вкусный, сам ел", 726, "https://disk.yandex.ru/i/Yq6WlkDqzZ-gZw", constants.candyGuid),
                    new Product("Молоко 1 л.", "Молоко деревенское", 76, "https://disk.yandex.ru/i/Yq6WlkDqzZ-gZw", constants.milkGuid),
                    new Product("Пирожок с капустой 1 шт.", "Пирожок бабушкин", 76, "https://disk.yandex.ru/i/Yq6WlkDqzZ-gZw", constants.bakingGuid),
                    new Product("Сок яблочный 1 л.", "Кислый", 90, "https://disk.yandex.ru/i/Yq6WlkDqzZ-gZw", constants.beveragesGuid),

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
