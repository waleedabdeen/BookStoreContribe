﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWFClient.Model;
using BookStoreWFClient.Modules.LoggingModule;

namespace BookStoreWFClient.Modules.ApiModule
{
    public class BookstoreService : IBookstoreService
    {
        private readonly string logTag = "Bookstore";

        public BookstoreService()
        {

        }
        // return the list of books matching the search string
        private IEnumerable<IBookDTO> GetBooks(string searchString)
        {
            try
            {
                return ResponseReader.GetBooks(RequestToServer.RequestBooks(searchString));
            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return null;
            }

        }

        // return the list of books matching the search string async 
        public Task<IEnumerable<IBookDTO>> GetBooksAsync(string searchString)
        {
            Task<IEnumerable<IBookDTO>> task = new Task<IEnumerable<IBookDTO>>(() =>
            {
                return GetBooks(searchString);
            });

            return task;

        }

        //TODO FIX this 
        public Task<string> GetNewId()
        {
            Task<string> task = new Task<string>(() => {
                string response = RequestToServer.RequestNewId("http://localhost:59759/api/util/getId");
                if (response == "error")
                {
                    return null;
                }
                return "to be fixed";
                //return ResponseReader.GetOrderId(response);
            });
            return task;
        }

        public Task<ReturnStatus> CheckOut(Cart cart, string userId)
        {
            Cart tempCart = cart;
            Task<ReturnStatus> taskCheckOut = new Task<ReturnStatus>(() => {

                IEnumerable<IBookDTO> availableBooks = CheckAvailability(tempCart, userId);
                if (availableBooks == null)
                {
                    return ReturnStatus.Undefined;
                }
                // set all cart items to unavailable
                tempCart.CartItems.ForEach((element) => element.IsAvailable = false);
                if (availableBooks.Count() == 0)
                {
                    return ReturnStatus.No;
                }
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
                if (availableBooks.Count() != tempCart.CartItems.Count())
                {
                    return ReturnStatus.No;
                }
                return ReturnStatus.Yes;
            });
            cart = tempCart;
            return taskCheckOut;
        }

        private IEnumerable<IBookDTO> CheckAvailability(Cart cart, string userId)
        {
            return ResponseReader.GetBooks(RequestToServer.CheckBooksAvailability(cart, userId));
        }

        public Task<OrderDetailsDTO> CreateNewOrder(Cart cart, string userId)
        {
            Task<OrderDetailsDTO> task = new Task<OrderDetailsDTO>(() => {
                return ResponseReader.GetOrderDetails(RequestToServer.CreateNewOrder(cart, userId));
            });
            return task;
        }

        public Task<string> RegiserNewAccount(string email, string password)
        {
            Task<string> task = new Task<string>(() => {
                return ResponseReader.RegistrationStatus(RequestToServer.RegisterNewAccount(email, password));
            });
            return task;
        }

        public Task<string> GetToken(string email, string password)
        {
            Task<string> task = new Task<string>(() => {
                return ResponseReader.TokenString(RequestToServer.GetToken(email, password));
            });
            return task;

        }
    }
}