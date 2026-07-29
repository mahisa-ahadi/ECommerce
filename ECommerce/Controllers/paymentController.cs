using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class paymentController : Controller
    {
        private readonly AppDbContext _context;

        public paymentController(AppDbContext context)
        {
            _context = context;
        }

    }
}
