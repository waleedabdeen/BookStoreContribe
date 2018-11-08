using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWFClient.Util;
using BookStoreWFClient.Modules.ApiModule;
using BookStoreWFClient.Model;

namespace BookStoreWFClient.Modules.OrderModule
{
    class OrderController
    {
        public async Task<OrderDetailsDTO> PlaceOrder()
        {
            BookstoreService bookstoreService = new BookstoreService();
            Task<OrderDetailsDTO> orderDetailsDTO = bookstoreService.CreateNewOrder(Global.Cart, User.Email);
            orderDetailsDTO.Start();
            return await orderDetailsDTO;
        }
    }
}
