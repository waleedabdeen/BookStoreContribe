using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookStoreWFClient.Model;
using BookStoreWFClient.Util;
using BookStoreWFClient.Modules.ApiModule;
using BookStoreWFClient.Interfaces;

namespace BookStoreWFClient.Modules.BookBrowserModule
{
    public partial class BookBrowserForm : BasicForm, IForm
    {
        IEnumerable<IBookDTO> books;
        BookstoreService bookstoreService;
        BookBrowserController controller;
        Form bookDetailsForm;
        string keyword;

        public BookBrowserForm(string _keyword = null)
        {
            keyword = _keyword;
            InitializeComponent();
            InitializeEvents();
            Global.BookBrowserForm = this;
            bookstoreService = new BookstoreService();
            controller = new BookBrowserController(this);
            books = new List<IBookDTO>();
        }

        public void RefreshBooks(string _keyword = null)
        {
            keyword = _keyword;
            ShowBooksGrid();
        }

        public void ShowBookDetails(BookDTO book)
        {
            bookDetailsForm = controller.GetBookDetailsForm(book);
            panelMain.Controls.Clear();
            panelMain.Controls.Add(bookDetailsForm);
            bookDetailsForm.Show();
        }

        private void ShowBooksGrid()
        {
            Form booksGridForm = controller.GetBooksGrid(keyword);
            panelMain.Controls.Clear();
            panelMain.Controls.Add(booksGridForm);
            booksGridForm.Show();
        }

        private void ShowCart()
        {
            Form cartForm = controller.GetCartForm();
            panelSide.Controls.Clear();
            panelSide.Controls.Add(cartForm);
            cartForm.Show();
        }

        public void InitializeEvents()
        {
            this.Load += new EventHandler(EH_FORM_LOAD);
        }

        private void EH_FORM_LOAD(object sedner, EventArgs args)
        {
            ShowBooksGrid();
            ShowCart();
        }
    }
}
