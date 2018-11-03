using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStoreAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using BookStoreAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using BookStoreAPI.Tests.TestDbSets;

namespace BookStoreAPI.Tests.Controllers
{
    [TestClass]
    public class OrdersControllerTest
    {
        [TestMethod]
        public async Task GetOrder_ShouldReturnOrderDetails()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            context.Orders.Add(DemoData.GetDemoOrder());

            // Act
            var controller = new OrdersController(context);
            var result = await controller.GetOrder("XyZ") as IHttpActionResult;
            var contentResult = result as OkNegotiatedContentResult<ApiResponse>;
            var order = contentResult.Content.Data as Order;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!contentResult.Content.Error);
            Assert.AreEqual("XyZ", order.Id);
        }

        //[TestMethod]
        //public void GetOrder_ShouldReturnUserOrders()
        //{
        //    // Arrange
        //    var context = new TestBookStoreAPIContext();
        //    context.Orders.Add(DemoData.GetDemoOrder());

        //    // Act
        //    var controller = new OrdersController(context);
        //    var result =  controller.GetOrders() as IHttpActionResult;
        //    var contentResult = result as OkNegotiatedContentResult<ApiResponse>;
        //    var orders = contentResult.Content.Data as List<Order>;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(!contentResult.Content.Error);
        //    Assert.AreEqual(1, orders.Count);
        //}

        [TestMethod]
        public async Task PostOrder_ShouldPostNewOrder()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            var testBook = DemoData.GetDemoBook();
            context.Books.Add(testBook);
            var cart = new Cart
            {
                Id = "TheCartId",
                //this item is in stock
                CartItems =
                new List<CartItem> { new CartItem(testBook.Id, 1) }
            };

            // Act
            var controller = new OrdersController(context);
            var result = await controller.PostOrder(cart) as IHttpActionResult;
            var contentResult = result as CreatedNegotiatedContentResult<ApiResponse>;
            var order = contentResult.Content.Data as OrderDetailsDTO;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!contentResult.Content.Error);
            Assert.IsNotNull(order.Id);
        }

        [TestMethod]
        public async Task PostOrder_ShouldReturnError()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            var testBook = DemoData.GetDemoBook();
            context.Books.Add(testBook);
            var cart = new Cart
            {
                Id = "TheCartId",
                //this item is out of stock
                CartItems =
                new List<CartItem> { new CartItem(testBook.Id, 5) }

            };

            // Act
            var controller = new OrdersController(context);
            var result = await controller.PostOrder(cart) as IHttpActionResult;
            var contentResult = result as OkNegotiatedContentResult<ApiResponse>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(contentResult.Content.Error);
        }
    }
}
