using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Modules.Navigation;
using BookStoreWFClient.Modules.BookBrowserModule;
using BookStoreWFClient.Model;
using BookStoreWFClient.Util;
using BookStoreWFClient.Modules.ApiModule;

namespace BookStoreWFClient.Modules.Bookstore
{
    public class BookstoreController
    {
        private NavigationForm navigation;        

        private Form content;

        public NavigationForm Navigation
        {
            get
            {
                if(this.navigation == null)
                {
                    navigation = new NavigationForm();
                    navigation.TopLevel = false;
                }
                return navigation;
            }
        }

        public Form Content
        {
            get
            {
                if(this.content == null)
                {
                    content = GetBookBrowser();
                    content.TopLevel = false;
                }
                return content;
            }
        }

        private Form GetBookBrowser()
        {
            return new BookBrowserForm();
        }

        public BookstoreController() { }

        public async void CheckOut(Cart cart, BasicForm sender)
        {
            BookstoreService bookstoreService = new BookstoreService();
            Task<ReturnStatus> taskCheckOut = bookstoreService.CheckOut(Global.Cart, "");
            taskCheckOut.Start();
            ReturnStatus checkoutStatus = await taskCheckOut;
            if (checkoutStatus == ReturnStatus.Undefined)
            {
                // the post request will handle unauthorized access
                // and it will show the error message
                return;
            }
            else if (checkoutStatus == ReturnStatus.No)
            {
                Global.CanCheckOut = false;
            }
            else
            {
                Global.CanCheckOut = true;
            }
            ShowCheckOutForm();
        }

        private void ShowCheckOutForm()
        {
            Global.ContentArea.Controls.Clear();
            CheckoutModule.CheckoutForm checkoutForm = new CheckoutModule.CheckoutForm();
            checkoutForm.TopLevel = false;
            checkoutForm.Dock = DockStyle.Fill;
            Global.ContentArea.Controls.Add(checkoutForm);
            checkoutForm.Show();
        }

    }
}
