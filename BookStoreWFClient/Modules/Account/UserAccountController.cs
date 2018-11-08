using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWFClient.Modules.ApiModule;
using BookStoreWFClient.Model;
using System.Windows.Forms;

namespace BookStoreWFClient.Modules.Account
{
    class UserAccountController
    {
        Form form;
        public UserAccountController(Form _form)
        {
            form = _form;
        }

        public async Task<string> Register(string email, string password)
        {
            BookstoreService bookstoreService= new BookstoreService();
            Task<string> task =  bookstoreService.RegiserNewAccount(email, password);
            task.Start();
            return await task;
        }

        public async Task<string> Login(string email, string password)
        {
            BookstoreService bookstoreService = new BookstoreService();
            Task<string> tokenTask = bookstoreService.GetToken(email, password);
            tokenTask.Start();
            return await tokenTask;
            //Task<string> loginTask = tokenTask.ContinueWith((task) =>
            //{
            //    return task.Result;
            //});
        }






    }
}
