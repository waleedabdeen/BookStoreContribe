using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookStoreAPI.Models;
using BookStoreAPI.Interfaces;
using BookStoreAPI.LoggingModule;

namespace BookStoreAPI.Controllers
{
    public class BooksController : ApiController
    {
        private IBookStoreAPIContext db = new ApplicationDbContext();
        private string logTag = "BooksController";

        public BooksController() { }

        public BooksController(IBookStoreAPIContext context)
        {
            db = context;
        }

        // GET: api/Books
        [ResponseType(typeof(BookDTO))]
        public IHttpActionResult GetBooks()
        {
            try
            {
                var books = from b in db.Books
                            select new BookDTO()
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Author = b.Author,
                                Price = b.Price
                            };
                return Ok(new ApiResponse(books));
            }
            catch(Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return InternalServerError();
            }
            
        }

        // GET: api/Books/5
        [ResponseType(typeof(BookDTO))]
        public async Task<IHttpActionResult> GetBook(string id)
        {
            try
            {
                Book book = await db.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }
                BookDTO bookDTO = new BookDTO { Id = book.Id, Title = book.Title, Author = book.Author, Price = book.Price };
                return Ok(new ApiResponse(bookDTO));
            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return InternalServerError();
            }
        }

        // GET: api/Books?keyword=whatdoyouwant
        [ResponseType(typeof(BookDTO))]
        public async Task<IHttpActionResult> GetSearch(string keyword)
        {
            try
            {
                string lowerKeyword = keyword.ToLower();
                Task<IHttpActionResult> resultTask = new Task<IHttpActionResult>(() =>
                {
                    IEnumerable<BookDTO> foundBooks = from b in db.Books
                                                      where b.Title.ToLower().Contains(lowerKeyword) ||
                                                      b.Author.ToLower().Contains(lowerKeyword)
                                                      select new BookDTO
                                                      {
                                                          Id = b.Id,
                                                          Title = b.Title,
                                                          Author = b.Author,
                                                          Price = b.Price
                                                      };
                    return Ok(new ApiResponse(foundBooks));
                });
                resultTask.Start();
                return await resultTask;
            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return InternalServerError();
            }
        }

        // POST : api/Books/availability
        [Route("api/Books/availability")]
        [ResponseType(typeof(BookDTO))]
        [Authorize]
        public async Task<IHttpActionResult> PostAvailability([FromBody]Cart value)
        {
            if (value == null)
            {
                return NotFound();
            }
            try
            {
                Task<IHttpActionResult> checkAvilablityTaks = new Task<IHttpActionResult>(() => {
                    List<IBookDTO> availableBooks = new List<IBookDTO>();
                    foreach (var item in value.CartItems)
                    {
                        if (BookAvailable(item.Book.Id, item.Quantity))
                        {
                            availableBooks.Add(item.Book);
                        }
                    }
                    if (availableBooks.Count() == value.CartItems.Count())
                    {
                        return Ok(new ApiResponse(availableBooks, "all available", false));
                    }
                    return Ok(new ApiResponse(availableBooks, "out of stock", false));
                });
                checkAvilablityTaks.Start();
                return await checkAvilablityTaks;
            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return InternalServerError();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookAvailable(string id, int quantity)
        {
            return DbFunctions.BookAvailable(id, quantity, db);
        }
    }
}