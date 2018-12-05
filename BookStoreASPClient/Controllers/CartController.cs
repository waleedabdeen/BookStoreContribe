using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookStoreASPClient.Models;
using BookStoreASPClient.Modules.ApiModule;
using BookStoreASPClient.Interfaces;

namespace BookStoreASPClient.Controllers
{
    public class CartController : Controller
    {
        BookstoreService bookstoreService;
        Cart cart;

        public CartController()
        {
            bookstoreService = new BookstoreService();
        }

        // GET: Cart
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Error = TempData["Cart_Error"];
            ViewBag.Message = TempData["Cart_Message"];
            return View(GetCart().CartItems);
        }

        // POST: Cart/Add
        [HttpPost]
        public async Task<ActionResult> Add(FormCollection collection)
        {
            //get book id & quantity from the form data
            string id = collection["Id"];
            int quantity = Convert.ToInt32(collection["quantity"]);
            if(string.IsNullOrEmpty(id) || quantity <= 0)
            {
                return RedirectToAction("Details", "Book", new { Id = id, Message = "failed, invalid id or quantity" });
            }

            int itemIndex = BookIndexInCart(id);
            if (itemIndex >= 0)
            {
                UpdateItemQuantity(itemIndex,quantity);
            }
            else
            {
                cart = GetCart();
                BookDTO book = await bookstoreService.GetBookDetailsAsync(id) as BookDTO;

                cart.CartItems.Add(new CartItem { Id = cart.CartItems.Count + 1, Book = book, Quantity = quantity });
                Session["Cart"] = cart;
            }
            
            //ViewBag.Message = "Added to cart";
            return RedirectToAction("Details", "Book", new { Id = id , Message = "Book Added To Cart"});
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                cart = GetCart();
                //int id = Convert.ToInt32(collection["id"]);
                int i = cart.CartItems.FindIndex((c) => c.Id == id);
                if (i >= 0)
                {
                    cart.CartItems.RemoveAt(i);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
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

        private int BookIndexInCart(string id)
        {
            cart = GetCart();
            int i = cart.CartItems.FindIndex((c) => c.Book.Id == id);
            return i;
        }

        private void UpdateItemQuantity(int itemIndex, int quantity)
        {
            cart = GetCart();
            cart.CartItems[itemIndex].Quantity += quantity;
            Session["Cart"] = cart;
        }

    }
}