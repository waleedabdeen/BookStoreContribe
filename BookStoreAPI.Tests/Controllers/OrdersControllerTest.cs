using NUnit.Framework;
using BookStoreAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using BookStoreAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using BookStoreAPI.Tests.TestDbSets;

namespace BookStoreAPI.Tests.Controllers
{
    [TestFixture]
    public class OrdersControllerTest
    {
        [Test]
        public async Task GetOrder_ShouldReturnOrderDetails()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            var order = DemoData.GetDemoOrder();
            context.Orders.Add(order);
            OrderItem orderItem = new OrderItem
            {
                Id = Util.Util.GetNewId(),
                OrderId = order.Id,
                BookId = "xta",
                SellingPrice = 499,
                Quantity = 1,
                ShippingStatus = 0,
                CreatedAt = new System.DateTime()
            };
            context.OrderItems.Add(orderItem);

            // Act
            var controller = new OrdersController(context);
            var result = await controller.GetOrder("XyZ") as IHttpActionResult;
            var contentResult = result as OkNegotiatedContentResult<ApiResponse>;
            var orderDetails = contentResult.Content.Data as OrderDetailsDTO;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!contentResult.Content.Error);
            Assert.AreEqual("XyZ", orderDetails.Id);
            Assert.AreEqual(499, orderDetails.TotalAmount);
        }

        [Test]
        public async Task PostOrder_ShouldPostNewOrder()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            var testBook = DemoData.GetDemoBook();
            context.Books.Add(testBook);
            var cart = new Cart
            {
                //this item is in stock
                CartItems =
                new List<CartItem> { new CartItem(DemoData.GetDTOfromBook(testBook), 1) }
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

        [Test]
        public async Task PostOrder_ShouldReturnError()
        {
            // Arrange
            var context = new TestBookStoreAPIContext();
            var testBook = DemoData.GetDemoBook();
            context.Books.Add(testBook);
            var cart = new Cart
            {
                //this item is out of stock
                CartItems =
                new List<CartItem> { new CartItem(DemoData.GetDTOfromBook(testBook), 5) }

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
