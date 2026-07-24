using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [Column("CartID")]
        public Guid CartID { get; set; } // Primary Key

        
        [Required]
        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        [Column("customerID")]
        public Guid? customerID { get; set; }

        [Column("geustID")]
        public Guid? guestID { get; set; }

        public Customer customer { get; set; }
        public Guest guest { get; set; }

    }
}
