using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{

    public enum PaymentStatus
    {
        Expired,
        PartiallyRefunded,
        Refunded,
        Cancelled,
        Failed,
        Completed,
        Authorized,
        Pending

    }

    [Table("payment")]
    public class payment
    {
        [Key]
        [Column("PaymentID")]
        public Guid PaymentID { get; set; } // Primary Key


        [Required]
        [Column("OrderID")]
        public Guid OrderID { get; set; } // Foreign Key to Orders table

        
        [Column("methodID")]
        public Guid? methodID { get; set; } // Foreign Key to PaymentMethod table

        [Column("paymentSatus")]
        public PaymentStatus? paymentStatus { get; set; } = PaymentStatus.Pending;

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        public Orders Order { get; set; }    // Navigation Property

        [ForeignKey(nameof(methodID))]
         public PaymentMethod paymentMethod { get; set; }
    }
    
}