using System;
using System.Windows.Forms;
using BookStoreWFClient.Util;
using BookStoreWFClient.Model;

namespace BookStoreWFClient.Modules.Bookstore
{
    public partial class BookstoreForm : BasicForm
    {
        public BookstoreController controller = new BookstoreController();
        public BookstoreForm()
        {
            InitializeComponent();
            InitializeEvents();
            Global.MainForm = this;
            Global.ContentArea = panelContent;
        }

        void InitializeEvents()
        {
            this.Load += new EventHandler(EH_FORM_LOAD);
        }
        
        private void LoadNavigation()
        {
            panelNavigation.Controls.Add(controller.Navigation);
            controller.Navigation.Show();
        }

        private void LoadBookBrowser()
        {
            panelContent.Controls.Add(controller.Content);
            controller.Content.Show();
        }

        void EH_FORM_LOAD(object sender, EventArgs args)
        {
            LoadNavigation();
            LoadBookBrowser();
        }
    }
}
