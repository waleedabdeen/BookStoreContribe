using System;
using System.Drawing;
using System.Windows.Forms;
using BookStoreWFClient.Util;

namespace BookStoreWFClient.Modules.Account
{
    public partial class UserAccountForm : Form
    {
        UserAccountController controller;

        public UserAccountForm()
        {
            InitializeComponent();
            InitializeEvents();
            controller = new UserAccountController(this);
        }

        public void InitializeEvents()
        {
            btnLogin.Click += new EventHandler(EH_BUTTON_CLICK_LOGIN);
            btnRegister.Click += new EventHandler(EH_BUTTON_CLICK_REGISTER);
            btnExit.Click += new EventHandler(EH_BUTTON_CLICK_EXIT);
        }

        public void EH_BUTTON_CLICK_REGISTER(object sender, EventArgs args)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        public async void EH_BUTTON_CLICK_LOGIN(object sender, EventArgs args)
        {
            string response = await controller.Login(textEmail.Text, textPassword.Text);
            if(string.IsNullOrEmpty(response) || response.StartsWith("ERROR")){
                labelMessage.Text = "Wrong username or password";
                labelMessage.ForeColor = Color.DarkRed;
            }
            else
            {
                labelMessage.Text = "Logged in successfully";
                labelMessage.ForeColor = Color.Green;
                User.Email = textEmail.Text;
                User.Token = response;
            }
            labelMessage.Visible = true;
        }
        public void EH_BUTTON_CLICK_EXIT(object sender, EventArgs args)
        {            
            this.Close();
            this.Dispose();
        }
    }
}
