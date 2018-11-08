using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Util;

namespace BookStoreWFClient.Modules.Account
{
    public partial class UserAccontForm : Form
    {
        UserAccountController controller;

        public UserAccontForm()
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

        public async void EH_BUTTON_CLICK_REGISTER(object sender, EventArgs args)
        {
            string message = await controller.Register(textEmail.Text, textPassword.Text);
            if (string.IsNullOrEmpty(message))
            {
                labelMessage.Text = "Something Went Wrong!";
                labelMessage.ForeColor = Color.DarkRed;
            }
            else if (message.StartsWith("ERROR"))
            {
                labelMessage.Text = message;
                labelMessage.ForeColor = Color.DarkRed;
            }
            else
            {
                labelMessage.Text = message;
                labelMessage.ForeColor = Color.Green;
            }
            labelMessage.Visible = true;
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
                Global.Token = response;
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
