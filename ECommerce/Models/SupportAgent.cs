using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
    [Table("SupportAgent")]
    public class SupportAgent : users
    {
        [Required]
        [Column("department")]
        [StringLength(100)]
        public String department { get; set; } = string.Empty;


        [Required]
        [Column("shiftType")]
        [StringLength(20)]
        public String shiftType { get; set; } = string.Empty;


        [Required]
        [Column("TicketSpecialization")]
        [StringLength(30)]
        public String TicketSpecialization { get; set; } = string.Empty;


        [Required]
        [Column("ExtensionNumber")]
        [StringLength(10)]
        public String ExtensionNumber { get; set; } = string.Empty;

        [Required]
        [Column("PerformanceRating")]
        public decimal PerformanceRating { get; set; } = 0.0m;


    }
}