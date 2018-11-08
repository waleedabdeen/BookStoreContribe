using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Model;
using BookStoreWFClient.Util;
using BookStoreWFClient.Modules.ApiModule;
using System.Threading;
using System.Globalization;

namespace BookStoreWFClient.Modules.BooksGridModule
{
    public partial class BooksGridForm : BasicForm
    {
        IEnumerable<IBookDTO> books = new List<IBookDTO>();
        BookstoreService bookstoreService = new BookstoreService();
        BooksGridController controller = new BooksGridController();
        Form bookDetailsForm;
        string keyword;

        public BooksGridForm(string _keyword = null)
        {
            keyword = _keyword;
            InitializeComponent();
            InitializeEvents();
        }

        public void RefreshBooks(string _keyword = null)
        {
            keyword = _keyword;
            GetAndShowBooks();
        }

        //private methods
        private async void GetAndShowBooks()
        {
            if (Global.BooksRequestSent)
            {
                return;
            }
            //Before 
            Global.BooksRequestSent = true;
            layoutBooks.Controls.Clear();
            ShowLoadingMessage();
            //check predraw
            //Get the books from server
            Task<IEnumerable<IBookDTO>> getBooksTask = controller.GetBooksFromService(keyword);
            getBooksTask.Start();
            books = await getBooksTask;
            //Draw Books
            Task drawTask = getBooksTask.ContinueWith((task) =>
            {
                if (task.Result == null || task.Result.Count() == 0)
                {
                    //TODO show no result
                    HideLoadingMessage();
                    ShowNoResultMessage();
                }
                else
                {
                    DrawHomeBooksItems();
                    HideLoadingMessage();
                    this.Invoke(new MethodInvoker(delegate
                    {
                        layoutBooks.Visible = true;
                    }));
                }
                Global.BooksRequestSent = false;
            });
        }

        private void DrawHomeBooksItems()
        {
            /*books = (List<Book>)bookstore.Books*/
            ;
            if (books == null)
            {
                //TODO show no results
                return;
            }
            int numberOfBooks = books.Count();
            foreach (BookDTO currentBook in books)
            {
                CreateHomeBookItem(currentBook);
            }
        }

        private void CreateHomeBookItem(BookDTO tempBook)
        {
            int column = 0, row = 0;
            int bookImageHeight = 200;
            int bookImageWidth = (int)(bookImageHeight * 0.65);

            //Setting culture info
            Thread.CurrentThread.CurrentCulture = new CultureInfo("se");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("se");

            //Create title label
            Label titleLabel = new Label();
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            titleLabel.Margin = new Padding(0);
            titleLabel.Padding = new Padding(5, 0, 0, 0);
            titleLabel.Size = new Size(186, 26);
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            titleLabel.Text = tempBook.Title.ToString();
            titleLabel.Tag = tempBook;

            //Create author label
            Label authorLabel = new Label();
            authorLabel.BackColor = Color.Transparent;
            authorLabel.Dock = DockStyle.Fill;
            authorLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            authorLabel.Margin = new Padding(0);
            authorLabel.Padding = new Padding(5, 0, 0, 0);
            authorLabel.Size = new Size(186, 26);
            authorLabel.TextAlign = ContentAlignment.MiddleLeft;
            authorLabel.Text = tempBook.Author.ToString();
            authorLabel.Tag = tempBook;
            authorLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            //Create price label
            Label priceLabel = new Label();
            priceLabel.BackColor = Color.Transparent;
            priceLabel.Dock = DockStyle.Fill;
            priceLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            priceLabel.ForeColor = Color.Tomato;
            priceLabel.Margin = new Padding(0);
            priceLabel.Padding = new Padding(5, 0, 0, 0);
            priceLabel.Size = new Size(186, 26);
            priceLabel.TextAlign = ContentAlignment.MiddleLeft;
            priceLabel.Text = tempBook.Price.ToString("C");
            priceLabel.Tag = tempBook;

            //Create book image panel
            Panel imagePanel = new Panel();
            imagePanel.BackColor = Color.Transparent;
            imagePanel.BackgroundImage = Properties.Resources.book2;
            imagePanel.BackgroundImageLayout = ImageLayout.Zoom;
            //imagePanel.Dock = DockStyle.Fill;
            imagePanel.Height = bookImageHeight;
            imagePanel.Width = bookImageWidth;
            imagePanel.Cursor = Cursors.Hand;
            imagePanel.Margin = new Padding(0);
            imagePanel.Cursor = Cursors.Hand;
            imagePanel.Name = tempBook.Title;
            imagePanel.Tag = tempBook;

            // add click events to the panel and labels
            imagePanel.Click += new EventHandler(EH_BUTTON_CLICK_BOOK);
            titleLabel.Click += new EventHandler(EH_BUTTON_CLICK_BOOK);
            authorLabel.Click += new EventHandler(EH_BUTTON_CLICK_BOOK);

            //Create TableLayout
            TableLayoutPanel tblConTrolHandler = new TableLayoutPanel();
            tblConTrolHandler.ColumnCount = 1;
            tblConTrolHandler.BackColor = Color.White;
            tblConTrolHandler.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblConTrolHandler.Dock = DockStyle.Fill;
            tblConTrolHandler.Margin = new Padding(3);
            tblConTrolHandler.RowCount = 4;
            tblConTrolHandler.Cursor = Cursors.Hand;
            tblConTrolHandler.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tblConTrolHandler.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblConTrolHandler.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblConTrolHandler.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblConTrolHandler.Controls.Add(imagePanel, 0, 0);
            tblConTrolHandler.Controls.Add(titleLabel, 0, 1);
            tblConTrolHandler.Controls.Add(authorLabel, 0, 2);
            tblConTrolHandler.Controls.Add(priceLabel, 0, 3);

            // if the end of column was reached then go to new row
            if (column != 0 && column % 4 == 0)
            {
                column = 0;
                row++;
            }
            // add the control to the interface

            // invoke required to solve the crose threading issue
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    layoutBooks.Controls.Add(tblConTrolHandler, column, row);
                }));
            }
            else
            {
                layoutBooks.Controls.Add(tblConTrolHandler, column, row);
            }

        }


        public void InitializeEvents()
        {
            this.Load += new EventHandler(EH_FORM_LOAD);
        }

        private void EH_FORM_LOAD(object sedner, EventArgs args)
        {
            GetAndShowBooks();
        }

        private void EH_BUTTON_CLICK_BOOK(object sender, EventArgs e)
        {
            BookDTO clickedBook = new BookDTO();
            if (!(sender is Panel) && !(sender is Label))
            {
                return;
            }
            else if (sender is Panel)
            {
                Panel clickedControl = (Panel)sender;
                clickedBook = (BookDTO)clickedControl.Tag;
            }
            else if (sender is Label)
            {
                Label clickedControl = (Label)sender;
                clickedBook = (BookDTO)clickedControl.Tag;
            }
            Global.BookBrowserForm.ShowBookDetails(clickedBook);
            this.Close();
            this.Dispose();
        }
    }
}
