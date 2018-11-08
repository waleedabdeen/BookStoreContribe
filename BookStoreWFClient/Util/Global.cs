using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Modules.Bookstore;
using BookStoreWFClient.Modules.Navigation;
using BookStoreWFClient.Model;
using BookStoreWFClient.Modules.CartModule;
using BookStoreWFClient.Modules.BookBrowserModule;

namespace BookStoreWFClient.Util
{
    public class Global
    {
        public static BookstoreForm MainForm{ get; set; }

        public static BookBrowserForm BookBrowserForm { get; set; }
        
        public static Panel ContentArea { get; set; }

        public static NavigationForm NavigationForm { get; set; }

        public static CartForm CartForm { get; set; }

        public static bool BooksRequestSent { get; set; }

        public static Cart Cart { get; set; }

        public static bool CanCheckOut { get; set; }

        public static string Token { get; set; }

        public static bool IsLoggedIn()
        {
            if (string.IsNullOrEmpty(Token))
            {
                return false;
            }
            return true;
        }
    }
}
