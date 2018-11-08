namespace BookStoreWFClient.Modules.BookDetailsModule
{
    partial class BookDetailsForm
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
            this.layoutBookItem = new System.Windows.Forms.TableLayoutPanel();
            this.layoutBookDetails = new System.Windows.Forms.TableLayoutPanel();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.textAuthor = new System.Windows.Forms.TextBox();
            this.labelDetailsTitle = new System.Windows.Forms.Label();
            this.labelDetailsAuthor = new System.Windows.Forms.Label();
            this.labelDetailsPrice = new System.Windows.Forms.Label();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.layoutAddToCart = new System.Windows.Forms.TableLayoutPanel();
            this.selectQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.picDetailsBook = new System.Windows.Forms.PictureBox();
            this.layoutBookItem.SuspendLayout();
            this.layoutBookDetails.SuspendLayout();
            this.layoutAddToCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailsBook)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutBookItem
            // 
            this.layoutBookItem.BackColor = System.Drawing.Color.GhostWhite;
            this.layoutBookItem.ColumnCount = 2;
            this.layoutBookItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.layoutBookItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutBookItem.Controls.Add(this.layoutBookDetails, 0, 0);
            this.layoutBookItem.Controls.Add(this.picDetailsBook, 1, 0);
            this.layoutBookItem.Controls.Add(this.layoutAddToCart, 1, 1);
            this.layoutBookItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutBookItem.Location = new System.Drawing.Point(0, 0);
            this.layoutBookItem.Name = "layoutBookItem";
            this.layoutBookItem.RowCount = 2;
            this.layoutBookItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutBookItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutBookItem.Size = new System.Drawing.Size(1082, 550);
            this.layoutBookItem.TabIndex = 6;
            // 
            // layoutBookDetails
            // 
            this.layoutBookDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutBookDetails.ColumnCount = 2;
            this.layoutBookDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.layoutBookDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.layoutBookDetails.Controls.Add(this.textPrice, 1, 2);
            this.layoutBookDetails.Controls.Add(this.textAuthor, 1, 1);
            this.layoutBookDetails.Controls.Add(this.labelDetailsTitle, 0, 0);
            this.layoutBookDetails.Controls.Add(this.labelDetailsAuthor, 0, 1);
            this.layoutBookDetails.Controls.Add(this.labelDetailsPrice, 0, 2);
            this.layoutBookDetails.Controls.Add(this.textTitle, 1, 0);
            this.layoutBookDetails.Location = new System.Drawing.Point(15, 15);
            this.layoutBookDetails.Margin = new System.Windows.Forms.Padding(15);
            this.layoutBookDetails.Name = "layoutBookDetails";
            this.layoutBookDetails.RowCount = 3;
            this.layoutBookDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.layoutBookDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.layoutBookDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.layoutBookDetails.Size = new System.Drawing.Size(619, 126);
            this.layoutBookDetails.TabIndex = 0;
            // 
            // textPrice
            // 
            this.textPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPrice.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textPrice.Location = new System.Drawing.Point(219, 85);
            this.textPrice.Name = "textPrice";
            this.textPrice.ReadOnly = true;
            this.textPrice.Size = new System.Drawing.Size(397, 32);
            this.textPrice.TabIndex = 5;
            // 
            // textAuthor
            // 
            this.textAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAuthor.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textAuthor.Location = new System.Drawing.Point(219, 44);
            this.textAuthor.Name = "textAuthor";
            this.textAuthor.ReadOnly = true;
            this.textAuthor.Size = new System.Drawing.Size(397, 32);
            this.textAuthor.TabIndex = 4;
            // 
            // labelDetailsTitle
            // 
            this.labelDetailsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDetailsTitle.AutoSize = true;
            this.labelDetailsTitle.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelDetailsTitle.Location = new System.Drawing.Point(3, 0);
            this.labelDetailsTitle.Name = "labelDetailsTitle";
            this.labelDetailsTitle.Size = new System.Drawing.Size(50, 41);
            this.labelDetailsTitle.TabIndex = 0;
            this.labelDetailsTitle.Text = "Title";
            // 
            // labelDetailsAuthor
            // 
            this.labelDetailsAuthor.AutoSize = true;
            this.labelDetailsAuthor.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelDetailsAuthor.Location = new System.Drawing.Point(3, 41);
            this.labelDetailsAuthor.Name = "labelDetailsAuthor";
            this.labelDetailsAuthor.Size = new System.Drawing.Size(69, 24);
            this.labelDetailsAuthor.TabIndex = 1;
            this.labelDetailsAuthor.Text = "Author";
            // 
            // labelDetailsPrice
            // 
            this.labelDetailsPrice.AutoSize = true;
            this.labelDetailsPrice.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelDetailsPrice.Location = new System.Drawing.Point(3, 82);
            this.labelDetailsPrice.Name = "labelDetailsPrice";
            this.labelDetailsPrice.Size = new System.Drawing.Size(53, 24);
            this.labelDetailsPrice.TabIndex = 2;
            this.labelDetailsPrice.Text = "Price";
            // 
            // textTitle
            // 
            this.textTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTitle.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textTitle.Location = new System.Drawing.Point(219, 3);
            this.textTitle.Name = "textTitle";
            this.textTitle.ReadOnly = true;
            this.textTitle.Size = new System.Drawing.Size(397, 32);
            this.textTitle.TabIndex = 3;
            // 
            // layoutAddToCart
            // 
            this.layoutAddToCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutAddToCart.ColumnCount = 2;
            this.layoutAddToCart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutAddToCart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.layoutAddToCart.Controls.Add(this.selectQuantity, 0, 0);
            this.layoutAddToCart.Controls.Add(this.btnAddToCart, 1, 0);
            this.layoutAddToCart.Location = new System.Drawing.Point(652, 278);
            this.layoutAddToCart.Name = "layoutAddToCart";
            this.layoutAddToCart.RowCount = 1;
            this.layoutAddToCart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutAddToCart.Size = new System.Drawing.Size(427, 51);
            this.layoutAddToCart.TabIndex = 4;
            // 
            // selectQuantity
            // 
            this.selectQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.selectQuantity.Font = new System.Drawing.Font("Tahoma", 12F);
            this.selectQuantity.Location = new System.Drawing.Point(22, 9);
            this.selectQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.selectQuantity.Name = "selectQuantity";
            this.selectQuantity.Size = new System.Drawing.Size(84, 32);
            this.selectQuantity.TabIndex = 3;
            this.selectQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToCart.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddToCart.Location = new System.Drawing.Point(133, 5);
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(289, 40);
            this.btnAddToCart.TabIndex = 2;
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            // 
            // picDetailsBook
            // 
            this.picDetailsBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picDetailsBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picDetailsBook.Location = new System.Drawing.Point(800, 37);
            this.picDetailsBook.Name = "picDetailsBook";
            this.picDetailsBook.Size = new System.Drawing.Size(130, 200);
            this.picDetailsBook.TabIndex = 1;
            this.picDetailsBook.TabStop = false;
            // 
            // BookDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 550);
            this.Controls.Add(this.layoutBookItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookDetailsForm";
            this.Text = "BookDetailsForm";
            this.layoutBookItem.ResumeLayout(false);
            this.layoutBookDetails.ResumeLayout(false);
            this.layoutBookDetails.PerformLayout();
            this.layoutAddToCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailsBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutBookItem;
        private System.Windows.Forms.TableLayoutPanel layoutBookDetails;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.TextBox textAuthor;
        private System.Windows.Forms.Label labelDetailsTitle;
        private System.Windows.Forms.Label labelDetailsAuthor;
        private System.Windows.Forms.Label labelDetailsPrice;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.PictureBox picDetailsBook;
        private System.Windows.Forms.TableLayoutPanel layoutAddToCart;
        private System.Windows.Forms.NumericUpDown selectQuantity;
        private System.Windows.Forms.Button btnAddToCart;
    }
}