using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Modules.Account;

namespace BookStoreWFClient.Model
{
    public class BasicForm : Form
    {
        Label message;
        PictureBox pictureBox;

        public BasicForm()
        {
            InErrorState = false;
        }

        public bool InErrorState { get; set; }

        private void CreateMessage(string text)
        {
            message = new Label();
            if(text!= null)
            {
                message.Text = text;
            }
            else
            {
                message.Text = "Error, no text";
            }
            message.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular);
            message.AutoSize = true;
            message.Location = new System.Drawing.Point(this.Width / 2 - message.Width / 2, this.Height / 2 - message.Height / 2);
            message.Visible = true;
            message.ForeColor = System.Drawing.Color.DimGray;
            message.BackColor = System.Drawing.Color.GhostWhite;
            message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            pictureBox = new PictureBox();
            pictureBox.Image = Properties.Resources.loading;
            pictureBox.Location = new System.Drawing.Point(this.Width / 2 + message.Width / 2 + 50, message.Top);
            pictureBox.Size = new System.Drawing.Size(30, 30);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = System.Drawing.Color.GhostWhite;
            pictureBox.Visible = true;
            pictureBox.Show();

        }

        public void ShowLoadingMessage()
        {

            this.Invoke(new MethodInvoker(delegate
            {
                CreateMessage("Please Wait..");
                this.Controls.Add(message);
                this.Controls.Add(pictureBox);
                message.BringToFront();
                pictureBox.BringToFront();
            }));

        }

        public void HideLoadingMessage()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.Controls.Remove(message);
                this.Controls.Remove(pictureBox);
                message.Dispose();
                pictureBox.Dispose();
            }));
        }

        public void ShowNoResultMessage()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.Controls.Clear();
                CreateMessage("No results!");
                this.Controls.Add(message);
                message.BringToFront();
                this.InErrorState = true;
            }));
        }

        public void ShowServerErrorMessage()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                MessageBox.Show("Couldn't connect to server or unauthorized access!","Server Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.InErrorState = true;
            }));
        }

        public void ShowUnauthorizedErrorMessage()
        {
            DialogResult dialogResult = MessageBox.Show("Your login session is expired, do you want to login?", "Unauthorized Access!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                UserAccountForm userAccontForm = new UserAccountForm();                
                userAccontForm.ShowDialog();
            }
        }
    }
}
