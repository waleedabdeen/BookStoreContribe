using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreASPClient.Models;

namespace BookStoreASPClient.Interfaces
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
