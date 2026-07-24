using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Key]
        [Column("OrderItemID")]
        public Guid OrderItemID { get; set; } // Primary Key

        [Required]
        [Column("OrderID")]
        public Guid OrderID { get; set; } // Foreign Key to Orders table

        [Required]
        [Column("ProductID")]
        public Guid ProductID { get; set; } // Foreign Key to Products table

        [Required]
        [Column("Quantity")]
        public int Quantity { get; set; } = 0;

        [Required]
        [Column("PriceAtPurchase")]
        public decimal PriceAtPurchase { get; set; } = 0.0m;

        public ICollection<Orders> orders { get; set; } = new List<Orders>(); // Navigation property to Orders
        public ICollection<products> products { get; set; } = new List<products>(); // Navigation property to Products
    }
}
