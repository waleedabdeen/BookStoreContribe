using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookStoreAPI.Models;
using BookStoreAPI.Interfaces;
using System.Web;
using Microsoft.AspNet.Identity;

namespace BookStoreAPI.Controllers
{
    [Authorize]
    public class OrdersController : ApiController
    {
        private IBookStoreAPIContext db = new ApplicationDbContext();

        public OrdersController() { }

        public OrdersController(IBookStoreAPIContext context)
        {
            db = context;
        }
        // GET: api/Orders
        [HttpGet]
        [Route("api/Orders")]
        public IHttpActionResult GetOrders()
        {
            string userId = User.Identity.GetUserId();

            var ordersInfoDetails = (from order in db.Orders
                                    where order.CustomerId == userId
                                    select new OrderDetailsDTO {
                                         Id = order.Id,
                                         OrderDate = order.OrderDate,
                                         Status = order.Status,
                                         CustomerId = order.CustomerId
                                    }).ToList();

            var ordersDetails = (from order in db.Orders
                                join item in db.OrderItems
                                on order.Id equals item.OrderId
                                where order.CustomerId == userId
                                select new OrderItemDTO
                                {
                                    Id = item.Id,
                                    OrderId = item.OrderId,
                                    BookId = item.BookId,
                                    Price = item.SellingPrice,
                                    Quantity = item.Quantity,
                                    Status = (int)item.ShippingStatus
                                }).ToList();
            ordersInfoDetails.ForEach(a => a.OrderItemsDTO = ordersDetails.Where(b => b.OrderId == a.Id));
            return Ok(new ApiResponse(ordersInfoDetails));
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> GetOrder(string id)
        {
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(new ApiResponse(order));
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(string id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            //db.Entry(order).State = EntityState.Modified;
            db.MarkAsModified(order);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        //[ResponseType(typeof(Order))]
        //public async Task<IHttpActionResult> PostOrder(Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Orders.Add(order);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (OrderExists(order.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        //}

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        [Route("api/Orders")]
        public async Task<IHttpActionResult> PostOrder(Cart cart)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            Order order = new Order();
            order.CreateOrderFromCart(cart, db);
            order.CustomerId = User.Identity.GetUserId();
            IEnumerable<OrderItem> orderItems = order.CreateOrderItemsFromCart(cart, db);

            if (orderItems.Count() == 0)
            {
                return Ok(new ApiResponse(null, "Items are not available", true));
            }
            db.Orders.Add(order);
            db.OrderItems.AddRange(orderItems);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            List<OrderItemDTO> orderItemsDTO = new List<OrderItemDTO>();
            foreach(OrderItem item in orderItems)
            {
                orderItemsDTO.Add(item.ToDTO());
            }
            OrderDetailsDTO orderDetailsDTO = new OrderDetailsDTO()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                OrderItemsDTO = orderItemsDTO
            };
            return Created("api/Orders", new ApiResponse(orderDetailsDTO));
            //return Ok(order.Id);
            //return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(string id)
        {
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(string id)
        {
            return db.Orders.Count(e => e.Id == id) > 0;
        }
    }
}