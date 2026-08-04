namespace ECommerce.Models
{
    public class CartItemViewModel
    {
        public Guid cartItemID { get; set; } 
        public Guid productId { get; set; }
        public string productName { get; set; } = string.Empty;

        public int Quantity { get; set; } = 0;
    }
}
