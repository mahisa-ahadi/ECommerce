using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
    [Table("Seller")]
    public class Seller : users
    {
        [Required]
        [Column("StoreName")]
        [StringLength(100)]
        public String StoreName { get; set; } = string.Empty;


        [Required]
        [Column("BusinessName")]
        public string BusinessName { get; set; } = string.Empty;


        [Required]
        [Column("BusinessLicenseNumber")]
        [StringLength(150)]
        public String BusinessLicenseNumber { get; set; } = string.Empty;


        [Required]
        [Column("taxNumber")]
        public string taxNumber {  get; set; } = string.Empty;


        [Column("StoreDescription")]
        [StringLength(500)]
        public String? StoreDescription { get; set; } = string.Empty;


        [Column("sellerRating")]
        public decimal? sellerRating { get; set; } = 0.0m;
        //one seller can have many products
        //public ICollection<Products> products { get; set; } = new List<Products>();
    }
}