using System.Windows.Forms;
using BookStoreWFClient.Util;
using BookStoreWFClient.Modules.BookBrowserModule;
using BookStoreWFClient.Modules.Account;

namespace BookStoreWFClient.Modules.Navigation
{
    class NavigationController
    {
        public NavigationController() { }
        
        public void ShowAllBooks(string keyword = null)
        {
            if (Global.ContentArea != null)
            {
                if (Global.BookBrowserForm == null)
                {
                    Global.BookBrowserForm = new BookBrowserForm(keyword)
                    {
                        TopLevel = false

                    };
                    Global.BookBrowserForm.Dock = DockStyle.Fill;
                    Global.BookBrowserForm.Name = "BOOK_BROWSER_KEY";
                }
                else
                {
                    Global.BookBrowserForm.RefreshBooks(keyword);
                    Global.ContentArea.Controls.Clear();
                    Global.ContentArea.Controls.Add(Global.BookBrowserForm);
                }
                Global.BookBrowserForm.Show();
                Global.BookBrowserForm.BringToFront();
            }
        }

        public void SearchBooks(string keyword)
        {
            this.ShowAllBooks(keyword);
        }

        public void ShowUserAccountForm()
        {
            UserAccountForm userAccontForm = new UserAccountForm();
            userAccontForm.Show();
        }
    }
}
