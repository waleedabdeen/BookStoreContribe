using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookStoreAPI.Models;
using BookStoreAPI.Interfaces;

namespace BookStoreAPI.Controllers
{
    [Authorize]
    public class BooksController : ApiController
    {
        private IBookStoreAPIContext db = new ApplicationDbContext();

        public BooksController() { }

        public BooksController(IBookStoreAPIContext context)
        {
            db = context;
        }

        // GET: api/Books
        [ResponseType(typeof(BookDTO))]
        [AllowAnonymous]
        public IHttpActionResult GetBooks()
        {
            //IQueryable < Book >
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

        // GET: api/Books/5
        [ResponseType(typeof(ApiResponse))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetBook(string id)
        {
            Book book = await db.Books.FindAsync(id);
            
            if (book == null)
            {
                return NotFound();
            }
            BookDTO bookDTO = new BookDTO { Id = book.Id, Title = book.Title, Author = book.Author, Price = book.Price };
            return Ok(new ApiResponse(bookDTO));
        }

        [ResponseType(typeof(ApiResponse))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetSearch(string keyword)
        {
            string lowerKeyword = keyword.ToLower();
            Task<IHttpActionResult> resultTask = new Task<IHttpActionResult>(() =>
            {
                IEnumerable<BookDTO> foundBooks = from b in db.Books
                                                where b.Title.ToLower().Contains(lowerKeyword) ||
                                                b.Author.ToLower().Contains(lowerKeyword)
                                                select new BookDTO {
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

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(string id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            //db.Entry(book).State = EntityState.Modified;
            db.MarkAsModified(book);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookExists(book.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        [Route("api/Books/availability")]
        public async Task<IHttpActionResult> Post([FromBody]Cart value)
        {
            if (value == null)
            {
                //return WrongDataResponse()
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
                //LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return InternalServerError();
            }
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(string id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(string id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }

        private bool BookAvailable(string id, int quantity)
        {
            //return db.Books.Count(a => a.Id == id && a.InStock >= quantity) == 1;
            return BookstoreService.BookAvailable(id, quantity, db);
        }
    }
}