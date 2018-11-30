using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using BookStoreAPI.Controllers;
using BookStoreAPI.Tests.TestDbSets;
using BookStoreAPI.Models;
using BookStoreAPI.Interfaces;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace BookStoreAPI.Tests.Controllers
{
    [TestFixture]
    public class BooksControllerTest
    {
        [Test]
        public async Task GetBook_ShouldReturnBookDetails()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            context.Books.Add(DemoData.GetDemoBook());

            // Act
            var controller = new BooksController(context);
            var result = await controller.GetBook("id1") as IHttpActionResult;
            var contentResult = result as OkNegotiatedContentResult<ApiResponse>;
            var book = contentResult.Content.Data as IBookDTO;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!contentResult.Content.Error);
            Assert.AreEqual("id1", book.Id);
        }

        [Test]
        public void GetBooks_ShouldReturnAllBooks()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            context.Books.Add(DemoData.GetDemoBook());

            // Act
            var controller = new BooksController(context);
            var result = controller.GetBooks() as IHttpActionResult;
            var contentResult = result as OkNegotiatedContentResult<ApiResponse>;
            var books = contentResult.Content.Data as IQueryable<IBookDTO>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!contentResult.Content.Error);
            Assert.AreEqual(1, books.Count());

        }

        [Test]
        public async Task GetSearch_ShouldReturnKewordMatchingBooks()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            context.Books.Add(new Book { Id = "id1", Title = "Generic Title", Author = "Cunning Basterd", Price = 499M, InStock = 1 });
            context.Books.Add(new Book { Id = "id2", Title = "Generic Title", Author = "Cunning Basterd", Price = 999M, InStock = 5 });
            context.Books.Add(new Book { Id = "id3", Title = "Desired", Author = "Author Here", Price = 960M, InStock = 0 });

            // Act
            var controller = new BooksController(context);
            var result = await controller.GetSearch("generic") as IHttpActionResult;
            var contentResult = result as OkNegotiatedContentResult<ApiResponse>;
            var books = contentResult.Content.Data as IQueryable<IBookDTO>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!contentResult.Content.Error);
            Assert.AreEqual(2, books.Count());
        }

        [Test]
        public async Task PostCheckAvailability_ShouldBeAvailable()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            var testBook = DemoData.GetDemoBook();
            context.Books.Add(testBook);
            var testBookDTO = DemoData.GetDTOfromBook(testBook);
            var cartItem = new CartItem { Book = testBookDTO , Quantity = 1 };
            var cart = new Cart()
            {
                CartItems = new List<CartItem> { cartItem }
            };

            // Act
            var controller = new BooksController(context);
            var result = await controller.PostAvailability(cart) as IHttpActionResult;
            var contentResult = result as OkNegotiatedContentResult<ApiResponse>;
            var availableBooks = contentResult.Content.Data as IEnumerable<IBookDTO>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!contentResult.Content.Error);
            Assert.AreEqual("all available", contentResult.Content.Message);
            Assert.AreEqual(testBookDTO, availableBooks.ElementAt(0));
        }

        [Test]
        public async Task PostCheckAvailability_ShouldBeOutOfStock()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            var testBook = DemoData.GetDemoBook();
            context.Books.Add(testBook);
            var cartItem = new CartItem { Book = DemoData.GetDTOfromBook(testBook), Quantity = 4 };
            var cart = new Cart
            {
                CartItems = new List<CartItem> { cartItem }
            };

            // Act
            var controller = new BooksController(context);
            var result = await controller.PostAvailability(cart) as IHttpActionResult;
            var contentResult = result as OkNegotiatedContentResult<ApiResponse>;
            var availableBooks = contentResult.Content.Data as IEnumerable<IBookDTO>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!contentResult.Content.Error);
            Assert.AreEqual("out of stock", contentResult.Content.Message);
            Assert.AreEqual(0, availableBooks.Count());
        }
    }
}
