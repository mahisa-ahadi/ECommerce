using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController (AppDbContext context)
        {
            _context = context;
        }

        //select all
        [HttpGet]
        public IActionResult Index()
        {
            var customer = _context.Customer.ToList();
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        //select one
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var customer = _context.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        //update
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var customer = _context.Customer.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerViewModel
            {
                UserID = customer.userID,
                Name = customer.name,
                WishlistVisibility = customer.WishlistVisibility,
                PreferredPaymentMethodID = customer.PreferredPaymentMethodID,

                PaymentMethods = _context.PaymentMethod
                    .Select(p => new SelectListItem
                    {
                        Value = p.MethodID.ToString(),
                        Text = p.MethodName
                    })
                    .ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.PaymentMethods = _context.PaymentMethod
                    .Select(p => new SelectListItem
                    {
                        Value = p.MethodID.ToString(),
                        Text = p.MethodName
                    })
                    .ToList();

                return View(model);
            }

            var customer = _context.Customer.Find(model.UserID);

            if (customer == null)
            {
                return NotFound();
            }

            customer.name = model.Name;
            customer.WishlistVisibility = model.WishlistVisibility;
            customer.PreferredPaymentMethodID = model.PreferredPaymentMethodID;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //insert
        [HttpGet]
        public IActionResult Create()
        { return View(); }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var customer = _context.Customer.Find(id);
            if (customer == null)
                return NotFound();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _context.Customer.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}
