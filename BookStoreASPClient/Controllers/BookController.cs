using System.Collections.Generic;
using System.Web.Mvc;
using BookStoreASPClient.Modules.ApiModule;
using System.Threading.Tasks;
using BookStoreASPClient.Models;

namespace BookStoreASPClient.Controllers
{
    public class BookController : Controller
    {
        BookstoreService bookstoreService;
        public BookController()
        {
            bookstoreService = new BookstoreService(); 
        }
        // GET: Book
        public async Task<ActionResult> Index()
        {
            IEnumerable<BookDTO> books = await bookstoreService.GetBooksAsync() as IEnumerable<BookDTO>;
            return View(books);
        }

        [HttpGet]
        public async Task<ActionResult> Search(string keyword)
        {
            IEnumerable<BookDTO> books = await bookstoreService.GetBooksAsync(keyword) as IEnumerable<BookDTO>;
            ViewBag.SearchKey = keyword;
            return View("Index",books);
        }

        // GET: Book/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpNotFoundResult();
            }
            BookDTO bookDTO = await bookstoreService.GetBookDetailsAsync(id) as BookDTO; 

            string message = Request.QueryString["Message"];
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
            }
            return View(bookDTO);
        }
    }
}
