using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Model;
using BookStoreWFClient.Modules.ApiModule;
using BookStoreWFClient.Modules.CartModule;
using BookStoreWFClient.Modules.BookDetailsModule;
using BookStoreWFClient.Util;
using BookStoreWFClient.Modules.BooksGridModule;

namespace BookStoreWFClient.Modules.BookBrowserModule
{
    class BookBrowserController
    {
        IEnumerable<IBookDTO> books = new List<IBookDTO>();
        BookstoreService bookstoreService = new BookstoreService();

        public BookBrowserController()
        {
            
        }

        public Task<IEnumerable<IBookDTO>> GetBooksFromService(string keyword = null)
        {
            return bookstoreService.GetBooksAsync(keyword);
        }

        public Form GetCartForm()
        {
            CartForm cartForm = new CartForm();
            cartForm.TopLevel = false;
            cartForm.Dock = DockStyle.Fill;
            cartForm.Name = "CART_KEY";
            return cartForm;
        }

        public Form GetBooksGrid(string keyword = null)
        {
            BooksGridForm booksGridForm = new BooksGridForm(keyword);
            booksGridForm.TopLevel = false;
            booksGridForm.Dock = DockStyle.Fill;
            booksGridForm.Name = "BOOKSGRID_KEY";
            return booksGridForm;
        }

        public Form GetBookDetailsForm(BookDTO book)
        {
            BookDetailsForm form = new BookDetailsForm(book);
            form.TopLevel = false;
            form.Dock = System.Windows.Forms.DockStyle.Fill;
            return form;
        }

    }
}
