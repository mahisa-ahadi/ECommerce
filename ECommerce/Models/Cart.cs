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

    }
}
