using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{ [Table("products")]
    
    public class products
    {
        [Key]
        [Column("productID")]
        public Guid productID { get; set; } // Primary Key


        [Required]
        [Column("productName")]
        public string productName { get; set; } = string.Empty;


        [Column("productDescription")]
        public string? productDescription { get; set; }

        [Required]
        [Column("price")]
        public decimal price { get; set; } = 0.0m;


        [Required]
        [Column("stockQuantity")]
        public int stockQuantity { get; set; } = 0;


        [Required]
        [Column("category")]
        public string category { get; set; }

        [Required]
        [Column("imageURL")]
        public string imageURL { get; set; }

        [Required]
        [Column("IsActive")]
        public bool IsActive { get; set; } = true;

        public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>(); // Navigation property to OrderItem
        public ICollection<CartItem> cartItems { get; set; } = new List<CartItem>(); // Navigation property to CartItem
    }
}