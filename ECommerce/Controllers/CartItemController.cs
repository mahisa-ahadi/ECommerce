using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CartItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
