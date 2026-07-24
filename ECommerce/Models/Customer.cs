using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
    [Table("Customer")]
    public class Customer : users
    {
        /*
         **it is also included in the Users class, so we don't need to include it here**
        [Key]
        [Column("userID")]
        public Guid UserID { get; set; } 
        */

        [Required]
        [Column("WishlistVisibility")]
        public bool WishlistVisibility { get; set; } = true;

        [Required]
        [Column("LoyaltyPoints")]
        public int LoyaltyPoints { get; set; } = 0;


        [Required]
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Column("PreferredPaymentMethodID")]
        public Guid? PreferredPaymentMethodID { get; set; } //FK to PaymentMethods table


        [ForeignKey(nameof(PreferredPaymentMethodID))]
        public PaymentMethod PreferredPaymentMethod { get; set; }
        public  ICollection<Orders> orders { get; set; }

        public ICollection<Cart> carts { get; set; }
        
    }
}
