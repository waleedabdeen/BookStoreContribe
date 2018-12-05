using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookStoreASPClient.Models;
using BookStoreASPClient.Modules.ApiModule;

namespace BookStoreASPClient.Controllers
{
    public class OrderController : Controller
    {
        BookstoreService bookstoreService;

        public OrderController()
        {
            bookstoreService = new BookstoreService();
        }

        // GET: Order
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult PlaceOrder()
        {
            if (!AccessToken.Valid())
            {
                return RedirectToAction("Login", "Account");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart.CartItems);
        }
        
        // GET: Order/CheckOut
        [HttpGet]
        public async Task<ActionResult> CheckOut()
        {
            if (!AccessToken.Valid())
            {
                return RedirectToAction("Login", "Account");
            }

            Cart cart = GetCart();
            Cart updatedCart = await bookstoreService.CheckOut(cart, AccessToken.Get());
            
            if(updatedCart == null || updatedCart.CartItems.Count() == 0)
            {
                TempData["Cart_Error"] = true;
                TempData["Cart_Message"] = "Something Went Wrong";
                return RedirectToAction("Index", "Cart");
            }

            Session["Cart"] = updatedCart;
            foreach (CartItem cartItem in updatedCart.CartItems)
            {
                if (!cartItem.IsAvailable)
                {
                    ViewBag.Error = true;
                    ViewBag.Message = "Not all items are available";
                    return View("CheckOut", cart.CartItems);
                }
            }

            return View("CheckOut", cart.CartItems);
        }

        [HttpPost]
        public async Task<ActionResult> PlaceOrder(IEnumerable<CartItem> items)
        {
            if (!AccessToken.Valid())
            {
                return RedirectToAction("Login", "Account");
            }
            Cart cart = new Cart();
            cart.CartItems = items.ToList();

            OrderDetailsDTO order = await bookstoreService.CreateNewOrder(cart, AccessToken.Get());
            if (order == null)
            {
                TempData["OrderStatus"] = false;
            }
            else
            {
                TempData["OrderStatus"] = true;
                TempData["CreatedOrder"] = order;
                TempData["Cart"] = cart;
                Session.Remove("Cart");
            }
            
            return RedirectToAction("OrderCreatedResult", "Order");
        }

        [HttpGet]
        public ActionResult OrderCreatedResult()
        {
            if (!AccessToken.Valid())
            {
                return RedirectToAction("Login", "Account");
            }

            bool created = (bool)TempData["OrderStatus"];
            if (!created)
            {
                ViewBag.Created = false;
                ViewBag.Message = "Error: could not create order";
                return View();

            }
            Cart cart = TempData["Cart"] as Cart;
            OrderDetailsDTO order = TempData["CreatedOrder"] as OrderDetailsDTO;
            if(cart == null || cart.CartItems.Count == 0 || order == null)
            {
                return RedirectToAction("Index", "Book");
            }
            

            //Set availability: it will be used in the view to show which items were not orderd
            //clear available flag
            cart.CartItems.ForEach((c) => c.IsAvailable = false);

            // set available flag based on order items
            // in case it is not ordered set isavailable to false
            foreach(var item in cart.CartItems)
            {
                if (order.OrderItemsDTO.FirstOrDefault((b) => b.BookId == item.Book.Id) != null)
                {
                    item.IsAvailable = true;
                }
            }

            if (cart.CartItems.Count() == order.OrderItemsDTO.Count())
            {
                ViewBag.Message = "All items were orderd";
            }
            else
            {
                ViewBag.Message = "Some items were not orderd!";
            }
            ViewBag.Created = true;
            OrderCreatedViewModel orderCreatedViewModel = new OrderCreatedViewModel();
            orderCreatedViewModel.OrderDetailsDTO = order;
            orderCreatedViewModel.CartItems = cart.CartItems;

            return View(orderCreatedViewModel);
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
            }
            return cart;
        }
    }
}
