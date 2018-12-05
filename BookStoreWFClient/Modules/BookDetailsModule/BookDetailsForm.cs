using System;
using System.Windows.Forms;
using BookStoreWFClient.Model;
using BookStoreWFClient.Util;

namespace BookStoreWFClient.Modules.BookDetailsModule
{
    public partial class BookDetailsForm : BasicForm
    {
        BookDTO book;
        BookDetailsController controller;

        public BookDetailsForm(BookDTO _book)
        {
            this.book = _book;
            InitializeComponent();
            InitializeEvents();
            controller = new BookDetailsController(this);
        }

        private void DisplayBookDetails()
        {
            textTitle.Text = book.Title;
            textAuthor.Text = book.Author;
            textPrice.Text = book.Price.ToString();
        }

        private void InitializeEvents()
        {
            this.Load += new EventHandler(EH_FORM_LOAD);
            btnAddToCart.Click += new EventHandler(EH_BUTTON_CLICK_ADD_TO_CART);
        }

        private void EH_FORM_LOAD(object sender, EventArgs args)
        {
            DisplayBookDetails();
        }
        private void EH_BUTTON_CLICK_ADD_TO_CART(object sender, EventArgs args)
        {
            if (book == null)
            {
                return;
            }
            try
            {
                Global.CartForm.AddItemToCartInterface(book, Convert.ToInt32(selectQuantity.Value));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
