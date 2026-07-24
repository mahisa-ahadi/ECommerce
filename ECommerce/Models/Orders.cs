using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
	[Table("Orders")]
	public class Orders
	{
		[Key]
		[Column("OrderID")]
		public Guid OrderID { get; set; } // Primary Key

		public enum OrderStatus
		{
			Refunded,
			Returned,
			Cancelled,
			Delivered,
			OutForDelivery,
			Shipped,
			Packed,
			Processing,
			Confirmed,
			Pending
		}

		[Required]
		[Column("orderStatus")]
		public OrderStatus orderStatus { get; set; } = OrderStatus.Pending;

		[Required]
		[Column("OrderDate")]
		public DateTime OrderDate { get; set; } = DateTime.UtcNow;
		[Required]
		[Column("TotalAmount")]
		public decimal TotalAmount { get; set; } = 0.0m;

		[Column("customerID")]
		public Guid? customerID { get; set; }
        public ICollection<payment> Payments { get; set; }
       = new List<payment>();
        public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>(); // Navigation property to OrderItems

		public shipmentDelivery ShipmentDelivery { get; set; }  // Navigation property to ShipmentDelivery

		public Customer customer { get; set; }

	}
}