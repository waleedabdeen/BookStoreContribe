namespace BookStoreWFClient.Modules.CartModule
{
    partial class CartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteBooks = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.listCartBooks = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Image = global::BookStoreWFClient.Properties.Resources.cart;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 38);
            this.label1.TabIndex = 10;
            this.label1.Text = "Shopping Cart";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeleteBooks
            // 
            this.btnDeleteBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteBooks.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnDeleteBooks.Location = new System.Drawing.Point(-1, 450);
            this.btnDeleteBooks.Name = "btnDeleteBooks";
            this.btnDeleteBooks.Size = new System.Drawing.Size(246, 40);
            this.btnDeleteBooks.TabIndex = 9;
            this.btnDeleteBooks.Text = "Remove Books";
            this.btnDeleteBooks.UseVisualStyleBackColor = true;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckout.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnCheckout.Location = new System.Drawing.Point(0, 496);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(245, 40);
            this.btnCheckout.TabIndex = 8;
            this.btnCheckout.Text = "Check Out";
            this.btnCheckout.UseVisualStyleBackColor = true;
            // 
            // listCartBooks
            // 
            this.listCartBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listCartBooks.FormattingEnabled = true;
            this.listCartBooks.Items.AddRange(new object[] {
            "Random Title - 2"});
            this.listCartBooks.Location = new System.Drawing.Point(-1, 41);
            this.listCartBooks.Name = "listCartBooks";
            this.listCartBooks.Size = new System.Drawing.Size(246, 403);
            this.listCartBooks.TabIndex = 7;
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(246, 539);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteBooks);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.listCartBooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CartForm";
            this.Text = "CartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteBooks;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.CheckedListBox listCartBooks;
    }
}