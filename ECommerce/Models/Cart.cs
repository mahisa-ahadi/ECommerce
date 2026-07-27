using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
    [Table("cart")]
    public class cart
    {
        [Key]
        [Column("cartID")]
        public Guid cartID { get; set; } // Primary Key

        
        [Required]
        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        [Column("customerID")]
        public Guid? customerID { get; set; }

        [Column("guestID")]
        public Guid? guestID { get; set; }

        public Customer customer { get; set; }
        public Guest guest { get; set; }
        public ICollection<CartItem> cartItems { get; set; }

    }
}
