using System;
using System.Windows.Forms;
using BookStoreWFClient.Util;
using BookStoreWFClient.Interfaces;

namespace BookStoreWFClient.Modules.Navigation
{
    public partial class NavigationForm : Form, IForm
    {
        NavigationController controller = new NavigationController();

        public NavigationForm()
        {
            InitializeComponent();
            InitializeEvents();
            Global.NavigationForm = this;
        }

        public void InitializeEvents()
        {
            btnHome.Click += new EventHandler(EH_BUTTON_CLICK_HOME);
            btnSearch.Click += new EventHandler(EH_BUTTON_CLICK_SEARCH);
            btnAccount.Click += new EventHandler(EH_BUTTON_CLICK_ACCOUNT);

            textSearch.KeyPress += new KeyPressEventHandler(EH_TEXT_SEARCH_KEY_PRESSED);

        }

        public void EH_BUTTON_CLICK_HOME(object sender, EventArgs args)
        {
            controller.ShowAllBooks();
        }

        private void EH_BUTTON_CLICK_SEARCH(object sender, EventArgs e)
        {
            controller.SearchBooks(textSearch.Text.ToString());
        }

        private void EH_BUTTON_CLICK_ACCOUNT(object sender, EventArgs e)
        {
            if (!User.IsLoggedIn())
            {
                controller.ShowUserAccountForm();
            }
            else
            {
                MessageBox.Show("Already logged in as: " + User.Email,"Logged In" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EH_TEXT_SEARCH_KEY_PRESSED(object sender, KeyPressEventArgs e)
        {
            //Check if the pressed key is enter : (13 ASCI code)
            if (e.KeyChar == 13)
            {
                controller.SearchBooks(textSearch.Text.ToString());
            }
        }
    }
}
