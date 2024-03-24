namespace OnlineShop.Models
{
    public class ProductCountViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost {  get; set; }
    }

}
