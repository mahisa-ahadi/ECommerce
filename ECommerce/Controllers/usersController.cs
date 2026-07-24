using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class usersController : Controller
    {
        private readonly AppDbContext _context;
        public usersController(AppDbContext context)
        {
            _context = context;
        }

        //select * from users
        [HttpGet]
        public IActionResult Index()
        {
            var users=_context.users.Where(u =>u.IsActive).ToList();
            return View(users);
        }
    }
}
