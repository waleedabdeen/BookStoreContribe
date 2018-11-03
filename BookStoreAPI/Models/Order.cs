using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Enums;

namespace BookStoreAPI.Models
{
    public class Order : IOrder
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public Order CreateOrderFromCart(Cart cart, IBookStoreAPIContext db)
        {
            this.Id = Util.Util.GetNewId();
            this.CustomerId = cart.Id;
            this.OrderDate = DateTime.Now;
            this.Status = OrderStatus.Open;
            this.CreatedAt = DateTime.Now;
            return this;

        }

        public IEnumerable<OrderItem> CreateOrderItemsFromCart(Cart cart, IBookStoreAPIContext db)
        {
            List<OrderItem> newOrderItems = new List<OrderItem>();
            foreach (CartItem item in cart.CartItems)
            {
                if (BookAvailable(item.BookId, item.Quantity, db))
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.Id = Util.Util.GetNewId();
                    orderItem.OrderId = this.Id;
                    orderItem.BookId = item.BookId;
                    orderItem.Quantity = item.Quantity;
                    orderItem.SellingPrice = db.Books.Find(orderItem.BookId).Price;
                    orderItem.ShippingStatus = Enums.ShippingStatus.NotShipped;
                    orderItem.CreatedAt = DateTime.Now;
                    newOrderItems.Add(orderItem);
                }
            }

            return newOrderItems;
        }


        private bool BookAvailable(string id, int quantity, IBookStoreAPIContext db)
        {
            return db.Books.Count(a => a.Id == id && a.InStock >= quantity) == 1;
            //return BookstoreService.BookAvailable(id, quantity, db);
        }
    }
}