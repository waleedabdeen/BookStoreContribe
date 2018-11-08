using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWFClient.Model;
using BookStoreWFClient.Modules.BookDetailsModule;
using BookStoreWFClient.Util;

namespace BookStoreWFClient.Modules.BookDetailsModule
{
    class BookDetailsController
    {
        public void ShowBookDetailsForm(BookDTO book)
        {
            BookDetailsForm form = new BookDetailsForm(book);
            form.TopLevel = false;
            form.Dock = System.Windows.Forms.DockStyle.Fill;
        }

    }
}
