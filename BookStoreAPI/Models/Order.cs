using System;
using System.Collections.Generic;
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

        public decimal TotalAmount { get; set; }

        public DateTime CreatedAt { get; set; }

        public void InitiateNewOrder()
        {
            this.Id = Util.Util.GetNewId();
            this.OrderDate = DateTime.Now;
            this.Status = OrderStatus.Open;
            this.CreatedAt = DateTime.Now;
        }

        public IEnumerable<OrderItem> CreateOrderItemsFromCart(Cart cart, IBookStoreAPIContext db)
        {
            List<OrderItem> newOrderItems = new List<OrderItem>();
            foreach (CartItem item in cart.CartItems)
            {
                if (BookAvailable(item.Book.Id, item.Quantity, db))
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.Id = Util.Util.GetNewId();
                    orderItem.OrderId = this.Id;
                    orderItem.BookId = item.Book.Id;
                    orderItem.Quantity = item.Quantity;
                    orderItem.SellingPrice = db.Books.Find(orderItem.BookId).Price;
                    orderItem.ShippingStatus = Enums.ShippingStatus.NotShipped;
                    orderItem.CreatedAt = DateTime.Now;
                    newOrderItems.Add(orderItem);
                }
            }
            UpdateTotal(newOrderItems, db);
            return newOrderItems;
        }

        private void UpdateTotal(IEnumerable<OrderItem> orderItems, IBookStoreAPIContext db)
        {
            decimal total = 0;
            foreach (OrderItem item in orderItems)
            {
                total += db.Books.Find(item.BookId).Price;
            }
            this.TotalAmount = total;
        }
        private bool BookAvailable(string id, int quantity, IBookStoreAPIContext db)
        {
            return BookstoreService.BookAvailable(id, quantity, db);
        }
    }
}