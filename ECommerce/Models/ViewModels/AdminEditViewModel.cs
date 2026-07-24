namespace ECommerce.Models.ViewModels
{
    public class AdminEditViewModel
    {
        public Guid userID { get; set; }

        public string name { get; set; }

        public string? phone { get; set; }

        public DateTime HireDate { get; set; }

        public string department { get; set; }

        public AdminAccessLevel AccessLevel { get; set; }

        public bool CanManageUsers { get; set; }

        public bool CanManageProducts { get; set; }
    }
}
