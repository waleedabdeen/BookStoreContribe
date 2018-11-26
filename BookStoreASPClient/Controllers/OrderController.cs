using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookStoreASPClient.Models;
using BookStoreASPClient.Modules.ApiModule;

namespace BookStoreASPClient.Controllers
{
    // Authorize
    public class OrderController : Controller
    {
        BookstoreService bookstoreService;

        public OrderController()
        {
            if (!AccessToken.Valid())
            {
                RedirectToAction("Login", "Account");
            }
            bookstoreService = new BookstoreService();
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        } 

        [HttpGet]
        public ActionResult PlaceOrder()
        {
            Cart cart = Session["Cart"] as Cart;
            return View(cart.CartItems);
        }

        
        [HttpGet]
        public async Task<ActionResult> CheckOut()
        {
            Cart cart = GetCart();
            if (!AccessToken.Valid())
            {
                return RedirectToAction("Login", "Account");
            }

            //cart = GetCart();
            Task<ReturnStatus> task = bookstoreService.CheckOut(ref cart, AccessToken.Get());
            task.Start();
            ReturnStatus status = await task;
            Session["Cart"] = cart;
            if (status == ReturnStatus.Undefined)
            {
                TempData["Cart_Error"] = true;
                TempData["Cart_Message"] = "Something Went Wrong";
                return RedirectToAction("Index","Cart");

            }
            else if (status == ReturnStatus.No)
            {
                ViewBag.Error = true;
                ViewBag.Message = "Not all items are available";
                return View("CheckOut", cart.CartItems);
            }
            else
            {
                return View("CheckOut", cart.CartItems);
            }
        }


        [HttpPost]
        public async Task<ActionResult> PlaceOrder(IEnumerable<CartItem> items)
        {
            Cart cart = new Cart();
            cart.CartItems = items.ToList();

            Task<OrderDetailsDTO> task = bookstoreService.CreateNewOrder(cart, AccessToken.Get());
            task.Start();
            OrderDetailsDTO order = await task;
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


            if (cart.CartItems == order.OrderItemsDTO)
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
