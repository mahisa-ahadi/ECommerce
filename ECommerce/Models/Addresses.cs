using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
    [Table("Addresses")]
    public class Addresses
    {
        [Key]
        [Column("AddressID")]
        public Guid AddressID { get; set; }



        [Required]
        [Column("ExactAddress")]
        [StringLength(200)]
        public String exactAddress { get; set; } = string.Empty;

        [Required]
        [Column("isDefault")]
        public bool isDefault { get; set; } = false;

        [Column("userID")]
        public Guid? userID { get; set; }  // FK to Users


        //one address can belong to many users
        public users user { get; set; }
    }
}
