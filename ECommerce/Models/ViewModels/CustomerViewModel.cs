
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Models.ViewModels
{
    public class CustomerViewModel
    {
        // Needed to identify which customer is being edited
        public Guid UserID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Wishlist Visibility")]
        public bool WishlistVisibility { get; set; }

        [Display(Name = "Preferred Payment Method")]
        public Guid? PreferredPaymentMethodID { get; set; }

        // Used to populate the dropdown list
        public List<SelectListItem> PaymentMethods { get; set; } = new();
    }
}