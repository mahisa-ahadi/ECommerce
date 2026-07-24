using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public enum AdminAccessLevel
    {
        FinanceAdmin,
        InventoryManager,
        MarketingManager,
        CustomerSupport,
        OrderManager,
        ProductManager,
        StoreAdmin,
        SuperAdmin
    }

    [Table("Admins")]
    public class Admins : users
    {
        /*
         **it is also included in the Users class, so we don't need to include it here**
        [Key]
        [Column("userID")]
        public Guid userID { get; set; } 
        */

        [Required]
        [Column("HireDate")]
        public DateTime HireDate { get; set; }

        [Required]
        [Column("department")]
        [StringLength(30)]
        public string department { get; set; } = string.Empty;

        [Required]
        [Column("AccessLevel")]
        public AdminAccessLevel AccessLevel { get; set; }

        [Required]
        [Column("CanManageUsers")]
        public bool CanManageUsers { get; set; } = false;

        [Required]
        [Column("CanManageProducts")]
        public bool CanManageProducts { get; set; } = false;
    }
}
