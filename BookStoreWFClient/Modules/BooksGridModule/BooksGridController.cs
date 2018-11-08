

using BookStoreWFClient.Model;
using BookStoreWFClient.Modules.ApiModule;
using BookStoreWFClient.Modules.BookDetailsModule;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreWFClient.Modules.BooksGridModule
{

   

    class BooksGridController
    {

        IEnumerable<IBookDTO> books = new List<IBookDTO>();
        BookstoreService bookstoreService = new BookstoreService();

        public BooksGridController()
        {


        }

        public Task<IEnumerable<IBookDTO>> GetBooksFromService(string keyword = null)
        {
            return bookstoreService.GetBooksAsync(keyword);
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
