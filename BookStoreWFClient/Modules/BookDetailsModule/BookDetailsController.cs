using BookStoreWFClient.Model;
using System.Windows.Forms;

namespace BookStoreWFClient.Modules.BookDetailsModule
{
    class BookDetailsController
    {
        private Form form;
        public BookDetailsController(Form _form)
        {
            form = _form;
        }

        public void ShowBookDetailsForm(BookDTO book)
        {
            BookDetailsForm form = new BookDetailsForm(book);
            form.TopLevel = false;
            form.Dock = System.Windows.Forms.DockStyle.Fill;
        }

    }
}
