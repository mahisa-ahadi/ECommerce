using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CartItemController : Controller
    {
        private readonly AppDbContext _context;
        public CartItemController(AppDbContext context)
        {
            _context = context;
        }
        //select all
        [HttpGet]
        public IActionResult Index()
        {
            var cartItem = _context.CartItem.ToList();
            List<CartItemViewModel> cartItemViewModels = new List<CartItemViewModel>();
            foreach (var item in cartItem)
            {
                var product = _context.products.Find(item.ProductID);
                if (product != null)
                {
                    cartItemViewModels.Add(new CartItemViewModel
                    {
                        cartItemID = item.cartItemID,
                        productId = product.productID,
                        productName = product.productName,
                        Quantity = item.Quantity
                    });
                }
            }
            return View(cartItemViewModels);
        }

        //select one
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var item = _context.CartItem.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);

        }

        //update
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = _context.CartItem.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }


        [HttpPost]
        public IActionResult Edit(CartItem cartItem)
        {
            var existing = _context.CartItem.Find(cartItem.cartItemID);
                if (existing == null)
                return NotFound();

            var product = _context.products.Find(cartItem.ProductID);

            existing.ProductID = cartItem.ProductID;
           
            existing.CartID = cartItem.CartID;
            existing.Quantity = cartItem.Quantity;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //delete
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var item = _context.CartItem.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Guid cartItemID)
        {
            var item = _context.CartItem.Find(cartItemID);
            if (item == null)
            {
                return NotFound();
            }
            _context.CartItem.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //insert
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(CartItem cartItem)
        {
       
            if (ModelState.IsValid)
            {
                cartItem.cartItemID = Guid.NewGuid();
                _context.CartItem.Add(cartItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartItem);
        }


       
    }
}
