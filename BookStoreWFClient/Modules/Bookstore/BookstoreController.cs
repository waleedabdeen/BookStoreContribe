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

        public BookstoreController()
        { }

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

        public async void CheckOut(Cart cart, BasicForm sender)
        {
            BookstoreService bookstoreService = new BookstoreService();
            Cart updatedCart = await bookstoreService.CheckOut(Global.Cart, User.Token);
            if (updatedCart == null)
            {
                Global.MainForm.ShowUnauthorizedErrorMessage();
                Global.CanCheckOut = false;
                return;
            }

            //assuming all items is available
            Global.CanCheckOut = true;
            foreach(CartItem item in updatedCart.CartItems)
            {
                if (!item.IsAvailable)
                {
                    //if one item is not available then can not check out (show message)
                    Global.CanCheckOut = false;
                }
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
