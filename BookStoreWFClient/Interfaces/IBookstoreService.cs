using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreWFClient.Model;

namespace BookStoreWFClient.Interfaces
{
    public interface IBookstoreService
    {
        Task<IEnumerable<IBookDTO>> GetBooksAsync(string searchString);

        Task<IBookDTO> GetBookDetailsAsync(string id);

        Task<Cart> CheckOut(Cart cart, string accessToken);

        Task<OrderDetailsDTO> CreateNewOrder(Cart cart, string accessToken);

        Task<string> RegiserNewAccount(string email, string password);

        Task<string> GetToken(string email, string password);

    }
}
