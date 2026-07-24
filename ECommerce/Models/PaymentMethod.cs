using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace ECommerce.Models
{
    [Table("PaymentMethod")]
    public class PaymentMethod
    {


        [Key]
        [Column("MethodID")]
        public Guid MethodID { get; set; } // Primary Key

        [Required]
        [Column("MethodName")]
        public string MethodName { get; set;} = string.Empty; // Name of the payment method (e.g., Credit Card, PayPal, etc.)

        [Column("Description")]
        public string? Description { get; set;} = string.Empty; // Description of the payment method 

        public List<Customer> Customers { get; set; } = new List<Customer>(); // Navigation property for related customers

        public ICollection<payment> payments { get; set; } = new List<payment>(); // Navigation property for related payments


    }
}
