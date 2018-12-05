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
            return await  bookstoreService.CreateNewOrder(Global.Cart, User.Token); 
        }
    }
}
