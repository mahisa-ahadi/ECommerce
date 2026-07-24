using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models

{

    public enum role { Guest, Customer, SupportAgent, Admin , Seller};

    [Table("users")]
    public class users
    {
        [Key]
        [Column("userID")]
        public Guid userID { get; set; } // Primary Key


        [Required]
        [Column("passwordHash")]
        [StringLength(225)]
        public String passwordHash { get; set; } = string.Empty;

        [Column("phone")]
        public string? phone { get; set; } = string.Empty;

        [Required]
        [Column("name")]
        public string name { get; set; }

        [Required]
        [Column("role")]
        public role Role { get; set; } = role.Guest;


        [Required]
        [Column("IsActive")]
        public bool IsActive { get; set; } = true;

        public ICollection<Addresses> Addresses { get; set; }
    }
}