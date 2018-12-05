﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreASPClient.Models;
using BookStoreASPClient.Interfaces;

namespace BookStoreASPClient.Modules.ApiModule
{
    public class BookstoreService : IBookstoreService
    {
        private readonly string logTag = "Bookstore";

        public BookstoreService() {}

        // return the details of one book using id
        public Task<IBookDTO> GetBookDetailsAsync(string id)
        {
            return Task.Run(() =>
                ResponseReader.GetBookDetails(RequestToServer.RequestBookDetails(id))
            );
        }

        // return the list of books matching the search string async 
        public Task<IEnumerable<IBookDTO>> GetBooksAsync(string searchString = "")
        {
            return Task.Run(() =>
                 ResponseReader.GetBooks(RequestToServer.RequestBooks(searchString))
            );
        }

        //TODO FIX this 
        public Task<string> GetNewId()
        {
            return Task.Run(() =>
            {
                string response = RequestToServer.RequestNewId("http://localhost:59759/api/util/getId");
                if (response == "error")
                {
                    return null;
                }
                return "to be fixed";
            }
            );
        }

        //TODO test it
        public async Task<Cart> CheckOut(Cart cart, string accessToken)
        {
            Cart tempCart = cart;

            IEnumerable<IBookDTO> availableBooks = await CheckAvailability(tempCart, accessToken);
            if (availableBooks == null)
            {
                return null;
            }
            // set all cart items to unavailable
            tempCart.CartItems.ForEach((element) => element.IsAvailable = false);
            foreach (BookDTO book in availableBooks)
            {
                for (int i = 0; i < tempCart.CartItems.Count; i++)
                {
                    if (tempCart.CartItems[i].Book.Id.Equals(book.Id))
                    {
                        tempCart.CartItems[i].IsAvailable = true;
                        break;
                    }
                }
            }
            return tempCart;        
        }

        private Task<IEnumerable<IBookDTO>> CheckAvailability(Cart cart, string accessToken)
        {
            return Task.Run(() =>
                ResponseReader.GetBooks(RequestToServer.CheckBooksAvailability(cart, accessToken))
            );
        }

        public Task<OrderDetailsDTO> CreateNewOrder(Cart cart, string accessToken)
        {
            return Task.Run(() =>
                ResponseReader.GetOrderDetails(RequestToServer.CreateNewOrder(cart, accessToken))
            );
        }

        public Task<string> RegiserNewAccount(string email, string password)
        {
            return Task.Run(()=>
                ResponseReader.RegistrationStatus(RequestToServer.RegisterNewAccount(email, password))
            );
        }

        public Task<string> GetToken(string email, string password)
        {
            return Task.Run(()=>
                ResponseReader.TokenString(RequestToServer.GetToken(email, password))
            );
        }
    }
}
