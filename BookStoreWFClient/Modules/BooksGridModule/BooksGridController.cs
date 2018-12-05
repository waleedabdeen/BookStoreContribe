using BookStoreWFClient.Model;
using BookStoreWFClient.Modules.ApiModule;
using BookStoreWFClient.Modules.BookDetailsModule;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Interfaces;

namespace BookStoreWFClient.Modules.BooksGridModule
{
    class BooksGridController
    {
        IEnumerable<IBookDTO> books;
        BookstoreService bookstoreService;
        Form form;

        public BooksGridController(Form _form)
        {
            books = new List<IBookDTO>();
            bookstoreService = new BookstoreService();
            form = _form;
        }

        public async Task<IEnumerable<IBookDTO>> GetBooksFromService(string keyword = null)
        {
            return await bookstoreService.GetBooksAsync(keyword);
        }

        public Form GetBookDetailsForm(BookDTO book)
        {
            BookDetailsForm form = new BookDetailsForm(book);
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            return form;
        }
    }

    
}
