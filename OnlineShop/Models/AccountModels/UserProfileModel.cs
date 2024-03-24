using OnlineShop.Models.DBModels;

namespace OnlineShop.Models.AccountModels
{
    public class UserProfileViewModel
    {
        public class UserProfileModel
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            // Добавьте другие свойства, которые вы хотите отобразить
        }
    }
}
