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
                    new Category(constants.fruitsGuid, "Овощи/Фрукты", "https://1.downloader.disk.yandex.ru/preview/23fa49f560db00d37235d70956de8900d46841278178240312d0ef0434a7fe39/inf/4qw5LfToK8L9AVWvBalSEeoxYJRLv7Zo9UllU78v6zl5X6DnRKg5NvXcsyzap3TQnkv2hyBp6bnMbUJpYFUuwA%3D%3D?uid=1397978672&filename=Fruits.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324"),
                    new Category(constants.readyGuid, "Готовая еда", "https://1.downloader.disk.yandex.ru/preview/b8d7c933a1a4c67d06262f11997f9553b9ec8d37008b37058a389840c31e6391/inf/AFuhnjJU1u8yDGP1Bqrs6esLDAI-pdQtrt0aokLu2wNlmDWcttqr9s2sgFq20DIXQd7RmPmkzZzwydfP_7Qnrg%3D%3D?uid=1397978672&filename=gotovaya.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&owner_uid=1397978672&tknv=v2&size=2560x1324"),
                    new Category(constants.seaFoodGuid, "Морепродукты", "https://3.downloader.disk.yandex.ru/preview/c462edbe9489a94f8503b80e7067b968d5f28cf49519b8c3d87c0a0f3af8c015/inf/M8NRc5muVmlCwXqHO_27QAiDZMB7f4vH3KgnBZQkuJ4MN6k0lHKOMo4NbAEWRPuYF6DgPaRX3GTF5Z7URzbjmQ%3D%3D?uid=1397978672&filename=Sea%20food.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324"),
                    new Category(constants.milkGuid, "Молочные продукты", "https://2.downloader.disk.yandex.ru/preview/29055883feb03020d321b81164925706706296f2e42a4c0a0049cd2d9accf4c3/inf/l2GpF-4UMui1QMeBfpnJ1-sLDAI-pdQtrt0aokLu2wMHeiVCybe22o9Uh1g2vT2QzS1V9xR03bdn3l1re_fChA%3D%3D?uid=1397978672&filename=Milk.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&owner_uid=1397978672&tknv=v2&size=2560x1324"),
                    new Category(constants.beveragesGuid, "Напитки", "https://1.downloader.disk.yandex.ru/preview/e9d5edc880adcadf3b2753c14747051bb7bd9d99d95a7383e634b5df01807584/inf/gQRtyBxvDTykP4BZaBj6iWbhXK9ihBPrFrb_zTgJGkLjvjySCX_bNGdahOKk9jqDb47LShYOFJmGi1NgO9q1fw%3D%3D?uid=1397978672&filename=Napitki.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324"),
                    new Category(constants.meatGuid, "Мясные изделия", "https://4.downloader.disk.yandex.ru/preview/210b7dd67870fbbb7e64e7e870cc6fe0ea265ea3e721cdc857cc30dc04391cba/inf/YKjetVPqHtATpPuntrMVbY14syslcaVk_OjZA1Kl0b7S74NrJSbAu6i20vcA4R1lp971G_SBNxy8z8lMKiQKZQ%3D%3D?uid=1397978672&filename=Meat.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324"),
                    new Category(constants.candyGuid, "Сладости", "https://3.downloader.disk.yandex.ru/preview/054ef7fefcc0da3da3125c8187642a6c1fc5037d6ac7d13af33f38fe74c334e2/inf/0ZqrRz4XcCPPI4v4dFO5Puq70jRnsf0EwVF2TeoWMO5nwbBbhVNVhhicx5xnjMJK8slA9beaAaajz5UOj56PhQ%3D%3D?uid=1397978672&filename=Сладости.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324"),
                    new Category(constants.bakingGuid, "Выпечка", "https://3.downloader.disk.yandex.ru/preview/c72a5f8dc8280d38890d9f0fc1a31a87b3d12b09468a43cb794e02f4d367eb38/inf/uCVQS-uxnJqNPpeS1PnAqaYFWvLcevViUBK_3jtfHYyE5SX8hkHFM8bkP0Jov6yCuw-QEHOhSaKbESeZiqehFw%3D%3D?uid=1397978672&filename=Выпечка%20фон.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324"),
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
                    new Product("Банан 1 шт.", "Банан бразильский", 76, "https://1.downloader.disk.yandex.ru/preview/5bff644162eda881d0d8e8f732fc8af6962e8c3538843c1653119656cb4db749/inf/dLldNFC0wGM-jjkPV65ZwTntks30zFOFMOF56lCZzScO9rRqWkJvjDe84mP-GrvHUjTO0MIMmrQzO2Tutu6VkA%3D%3D?uid=1397978672&filename=Product.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324", constants.fruitsGuid),
                    new Product("Говядина вырезка 1 кг.", "Говядина Земная", 590, "https://1.downloader.disk.yandex.ru/preview/5bff644162eda881d0d8e8f732fc8af6962e8c3538843c1653119656cb4db749/inf/dLldNFC0wGM-jjkPV65ZwTntks30zFOFMOF56lCZzScO9rRqWkJvjDe84mP-GrvHUjTO0MIMmrQzO2Tutu6VkA%3D%3D?uid=1397978672&filename=Product.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324", constants.meatGuid),
                    new Product("Яки нику", "Очень вкусно", 290, "https://1.downloader.disk.yandex.ru/preview/5bff644162eda881d0d8e8f732fc8af6962e8c3538843c1653119656cb4db749/inf/dLldNFC0wGM-jjkPV65ZwTntks30zFOFMOF56lCZzScO9rRqWkJvjDe84mP-GrvHUjTO0MIMmrQzO2Tutu6VkA%3D%3D?uid=1397978672&filename=Product.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324", constants.readyGuid),
                    new Product("Креветки северные 1 кг.", "'Креветки северные, мертвые", 600, "https://1.downloader.disk.yandex.ru/preview/5bff644162eda881d0d8e8f732fc8af6962e8c3538843c1653119656cb4db749/inf/dLldNFC0wGM-jjkPV65ZwTntks30zFOFMOF56lCZzScO9rRqWkJvjDe84mP-GrvHUjTO0MIMmrQzO2Tutu6VkA%3D%3D?uid=1397978672&filename=Product.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324", constants.seaFoodGuid),
                    new Product("Торт Наполенон 1 кг.", "Торт вкусный, сам ел", 726, "https://1.downloader.disk.yandex.ru/preview/5bff644162eda881d0d8e8f732fc8af6962e8c3538843c1653119656cb4db749/inf/dLldNFC0wGM-jjkPV65ZwTntks30zFOFMOF56lCZzScO9rRqWkJvjDe84mP-GrvHUjTO0MIMmrQzO2Tutu6VkA%3D%3D?uid=1397978672&filename=Product.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324", constants.candyGuid),
                    new Product("Молоко 1 л.", "Молоко деревенское", 76, "https://1.downloader.disk.yandex.ru/preview/5bff644162eda881d0d8e8f732fc8af6962e8c3538843c1653119656cb4db749/inf/dLldNFC0wGM-jjkPV65ZwTntks30zFOFMOF56lCZzScO9rRqWkJvjDe84mP-GrvHUjTO0MIMmrQzO2Tutu6VkA%3D%3D?uid=1397978672&filename=Product.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324", constants.milkGuid),
                    new Product("Пирожок с капустой 1 шт.", "Пирожок бабушкин", 76, "https://1.downloader.disk.yandex.ru/preview/5bff644162eda881d0d8e8f732fc8af6962e8c3538843c1653119656cb4db749/inf/dLldNFC0wGM-jjkPV65ZwTntks30zFOFMOF56lCZzScO9rRqWkJvjDe84mP-GrvHUjTO0MIMmrQzO2Tutu6VkA%3D%3D?uid=1397978672&filename=Product.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324", constants.bakingGuid),
                    new Product("Сок яблочный 1 л.", "Кислый", 90, "https://1.downloader.disk.yandex.ru/preview/5bff644162eda881d0d8e8f732fc8af6962e8c3538843c1653119656cb4db749/inf/dLldNFC0wGM-jjkPV65ZwTntks30zFOFMOF56lCZzScO9rRqWkJvjDe84mP-GrvHUjTO0MIMmrQzO2Tutu6VkA%3D%3D?uid=1397978672&filename=Product.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1397978672&tknv=v2&size=2560x1324", constants.beveragesGuid),

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
