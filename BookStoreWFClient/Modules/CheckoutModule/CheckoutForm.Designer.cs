namespace BookStoreWFClient.Modules.CheckoutModule
{
    partial class CheckoutForm
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
            this.panelCOBooksListWrapper = new System.Windows.Forms.Panel();
            this.panelCOBooksList = new System.Windows.Forms.Panel();
            this.layoutCOBookListTableHeader = new System.Windows.Forms.TableLayoutPanel();
            this.labelCOQuantityTitleL = new System.Windows.Forms.Label();
            this.labelCOBookTitleL = new System.Windows.Forms.Label();
            this.lableCOPriceTitleL = new System.Windows.Forms.Label();
            this.panelTotalAmount = new System.Windows.Forms.Panel();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.labelCOTotalAmount = new System.Windows.Forms.Label();
            this.labelCOTotalAmountTitleL = new System.Windows.Forms.Label();
            this.panelCOBooksListWrapper.SuspendLayout();
            this.layoutCOBookListTableHeader.SuspendLayout();
            this.panelTotalAmount.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCOBooksListWrapper
            // 
            this.panelCOBooksListWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCOBooksListWrapper.BackColor = System.Drawing.Color.GhostWhite;
            this.panelCOBooksListWrapper.Controls.Add(this.panelCOBooksList);
            this.panelCOBooksListWrapper.Controls.Add(this.layoutCOBookListTableHeader);
            this.panelCOBooksListWrapper.Location = new System.Drawing.Point(0, -1);
            this.panelCOBooksListWrapper.Name = "panelCOBooksListWrapper";
            this.panelCOBooksListWrapper.Size = new System.Drawing.Size(744, 500);
            this.panelCOBooksListWrapper.TabIndex = 1;
            // 
            // panelCOBooksList
            // 
            this.panelCOBooksList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCOBooksList.AutoScroll = true;
            this.panelCOBooksList.Location = new System.Drawing.Point(3, 41);
            this.panelCOBooksList.Name = "panelCOBooksList";
            this.panelCOBooksList.Size = new System.Drawing.Size(738, 459);
            this.panelCOBooksList.TabIndex = 6;
            // 
            // layoutCOBookListTableHeader
            // 
            this.layoutCOBookListTableHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutCOBookListTableHeader.AutoScroll = true;
            this.layoutCOBookListTableHeader.ColumnCount = 3;
            this.layoutCOBookListTableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.layoutCOBookListTableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutCOBookListTableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutCOBookListTableHeader.Controls.Add(this.labelCOQuantityTitleL, 1, 0);
            this.layoutCOBookListTableHeader.Controls.Add(this.labelCOBookTitleL, 0, 0);
            this.layoutCOBookListTableHeader.Controls.Add(this.lableCOPriceTitleL, 2, 0);
            this.layoutCOBookListTableHeader.Location = new System.Drawing.Point(2, 3);
            this.layoutCOBookListTableHeader.Name = "layoutCOBookListTableHeader";
            this.layoutCOBookListTableHeader.RowCount = 1;
            this.layoutCOBookListTableHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutCOBookListTableHeader.Size = new System.Drawing.Size(739, 32);
            this.layoutCOBookListTableHeader.TabIndex = 2;
            // 
            // labelCOQuantityTitleL
            // 
            this.labelCOQuantityTitleL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCOQuantityTitleL.AutoSize = true;
            this.labelCOQuantityTitleL.Location = new System.Drawing.Point(504, 7);
            this.labelCOQuantityTitleL.Name = "labelCOQuantityTitleL";
            this.labelCOQuantityTitleL.Size = new System.Drawing.Size(61, 17);
            this.labelCOQuantityTitleL.TabIndex = 4;
            this.labelCOQuantityTitleL.Text = "Quantity";
            this.labelCOQuantityTitleL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCOBookTitleL
            // 
            this.labelCOBookTitleL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCOBookTitleL.AutoSize = true;
            this.labelCOBookTitleL.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCOBookTitleL.Location = new System.Drawing.Point(3, 7);
            this.labelCOBookTitleL.Name = "labelCOBookTitleL";
            this.labelCOBookTitleL.Size = new System.Drawing.Size(39, 17);
            this.labelCOBookTitleL.TabIndex = 0;
            this.labelCOBookTitleL.Text = "Book";
            // 
            // lableCOPriceTitleL
            // 
            this.lableCOPriceTitleL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lableCOPriceTitleL.AutoSize = true;
            this.lableCOPriceTitleL.Location = new System.Drawing.Point(646, 7);
            this.lableCOPriceTitleL.Name = "lableCOPriceTitleL";
            this.lableCOPriceTitleL.Size = new System.Drawing.Size(37, 17);
            this.lableCOPriceTitleL.TabIndex = 3;
            this.lableCOPriceTitleL.Text = "Price";
            // 
            // panelTotalAmount
            // 
            this.panelTotalAmount.BackColor = System.Drawing.Color.GhostWhite;
            this.panelTotalAmount.Controls.Add(this.btnPlaceOrder);
            this.panelTotalAmount.Controls.Add(this.labelCOTotalAmount);
            this.panelTotalAmount.Controls.Add(this.labelCOTotalAmountTitleL);
            this.panelTotalAmount.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTotalAmount.Location = new System.Drawing.Point(747, 0);
            this.panelTotalAmount.Name = "panelTotalAmount";
            this.panelTotalAmount.Size = new System.Drawing.Size(235, 503);
            this.panelTotalAmount.TabIndex = 6;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlaceOrder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceOrder.Location = new System.Drawing.Point(4, 460);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(228, 40);
            this.btnPlaceOrder.TabIndex = 2;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            // 
            // labelCOTotalAmount
            // 
            this.labelCOTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCOTotalAmount.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCOTotalAmount.Location = new System.Drawing.Point(13, 89);
            this.labelCOTotalAmount.Name = "labelCOTotalAmount";
            this.labelCOTotalAmount.Size = new System.Drawing.Size(210, 29);
            this.labelCOTotalAmount.TabIndex = 1;
            this.labelCOTotalAmount.Text = "0.0";
            this.labelCOTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCOTotalAmountTitleL
            // 
            this.labelCOTotalAmountTitleL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCOTotalAmountTitleL.AutoSize = true;
            this.labelCOTotalAmountTitleL.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCOTotalAmountTitleL.Location = new System.Drawing.Point(14, 40);
            this.labelCOTotalAmountTitleL.Name = "labelCOTotalAmountTitleL";
            this.labelCOTotalAmountTitleL.Size = new System.Drawing.Size(131, 24);
            this.labelCOTotalAmountTitleL.TabIndex = 0;
            this.labelCOTotalAmountTitleL.Text = "Total Amount";
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 503);
            this.Controls.Add(this.panelTotalAmount);
            this.Controls.Add(this.panelCOBooksListWrapper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckoutForm";
            this.Text = "CheckoutForm";
            this.panelCOBooksListWrapper.ResumeLayout(false);
            this.layoutCOBookListTableHeader.ResumeLayout(false);
            this.layoutCOBookListTableHeader.PerformLayout();
            this.panelTotalAmount.ResumeLayout(false);
            this.panelTotalAmount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCOBooksListWrapper;
        private System.Windows.Forms.Panel panelCOBooksList;
        private System.Windows.Forms.TableLayoutPanel layoutCOBookListTableHeader;
        private System.Windows.Forms.Label labelCOQuantityTitleL;
        private System.Windows.Forms.Label labelCOBookTitleL;
        private System.Windows.Forms.Label lableCOPriceTitleL;
        private System.Windows.Forms.Panel panelTotalAmount;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Label labelCOTotalAmount;
        private System.Windows.Forms.Label labelCOTotalAmountTitleL;
    }
}