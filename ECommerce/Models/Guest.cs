using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models

	{
	[Table("Guest")]
	public class Guest : users
		{
		[Required]
		[Column("GuestCartID")]
		public Guid GuestCartID { get; set; }

		[Required]
		[Column("SessionStartTime")]
		public DateTime SessionStartTime { get; set; } = DateTime.UtcNow;

		[Required]
		[Column("SessionExpiryTime")]
		public DateTime SessionExpiryTime { get; set; } = DateTime.UtcNow.AddHours(1);

		public cart carts { get; set; }
    }	
	}
