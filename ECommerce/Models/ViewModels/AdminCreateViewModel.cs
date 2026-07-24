namespace ECommerce.Models.ViewModels
{
    public class AdminCreateViewModel
    {
        // User fields
        public string name { get; set; }
        public string phone { get; set; }
        public string passwordHash { get; set; }

        // Admin fields
        public DateTime HireDate { get; set; }
        public string department { get; set; }
        public AdminAccessLevel AccessLevel { get; set; }
        public bool CanManageUsers { get; set; }
        public bool CanManageProducts { get; set; }
    }
}
