using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
    public enum shipmentStatus
    {
        Lost,
        ReturnedToSender,
        DeliveryFailed,
        Delivered,
        OutForDelivery,
        InTransit,
        Shipped,
        Packed,
        Processing,
        Pending
    }

    [Table("shipmentDelivery")]
    public class shipmentDelivery
    {
        [Key]
        [Column("shipmentID")]
        public Guid shipmentDeliveryID { get; set; } // Primary Key
      
        
        
        [Required]
        [Column("orderID")]
        public Guid orderID { get; set; } // Foreign Key to order table


        [Required]
        [Column("TrackingNumber")]
        public string TrackingNumber { get; set; } = string.Empty; // Tracking number for the shipment

        [Required]
        [Column("carrier")]
        public string carrier { get; set; } = string.Empty; // Carrier for the shipment

        [Required]
        [Column("shippedDate")]
        public DateTime shippedDate { get; set; } = DateTime.UtcNow; // Date when the shipment was shipped

        [Required]
        [Column("deliveryDate")]
        public DateTime deliveryDate { get; set; } = DateTime.UtcNow.AddDays(5); // Expected delivery date

        [Required]
        [Column("shipmentStatus")]
      
        public shipmentStatus shipmentStatus { get; set; } = shipmentStatus.Pending; // Status of the shipment

        public Orders orders { get; set; }  // Navigation property to Orders

    }
}