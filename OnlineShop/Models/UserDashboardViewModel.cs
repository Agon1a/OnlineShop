using OnlineShop.Models.DBModels;

namespace OnlineShop.Models
{
    public class UserDashboardViewModel
    {
        public User User { get; set; }
        public List<UserAddress> UserAddresses { get; set; }
        public List<Order> Orders { get; set; }
    }
}
