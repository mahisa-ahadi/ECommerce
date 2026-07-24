using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
    [Table("CartItem")]
    public class CartItem
    {
        [Key]
        [Column("CartItemID")]
        public Guid CartItemID { get; set; } // Primary Key

        [Required]
        [Column("ProductID")]
        public Guid ProductID { get; set; } // Foreign Key to Products table
        [Required]
        [Column("CartID")]
        public Guid CartID { get; set; } // Foreign Key to Cart table

        [Required]
        [Column("Quantity")]
        public int Quantity { get; set; } = 0;

        public ICollection<Cart> carts { get; set; }= new List<Cart>(); // Navigation property to Cart

        public ICollection<products> products { get; set; } = new List<products>(); // Navigation property to Products


    }
}
