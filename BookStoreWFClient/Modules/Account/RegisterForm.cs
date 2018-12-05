using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BookStoreWFClient.Modules.Account
{
    public partial class RegisterForm : Form
    {
        UserAccountController controller;
        public RegisterForm()
        {
            InitializeComponent();
            InitializeEvents();
            controller = new UserAccountController(this);
        }

        public void InitializeEvents()
        {
            btnCreateAccount.Click += new EventHandler(EH_BUTTON_CLICK_REGISTER);
            btnCancel.Click += new EventHandler(EH_BUTTON_CLICK_EXIT);
        }

        public async void EH_BUTTON_CLICK_REGISTER(object sender, EventArgs args)
        {
            if(string.IsNullOrEmpty(textEmail.Text) || string.IsNullOrEmpty(textPassword.Text)
                || textPassword.Text != textConfirmPassword.Text)
            {
                labelMessage.Text = "Fill all the fields and make sure the two passwords match";
                labelMessage.ForeColor = Color.DarkRed;
                return;
            }
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
                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.Dispose();
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
