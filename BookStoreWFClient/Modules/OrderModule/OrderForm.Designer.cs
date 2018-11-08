namespace BookStoreWFClient.Modules.OrderModule
{
    partial class OrderForm
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
            this.panelOrder = new System.Windows.Forms.Panel();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.labelTotalAmountT = new System.Windows.Forms.Label();
            this.labelOrderMessage = new System.Windows.Forms.Label();
            this.panelOrderSlip = new System.Windows.Forms.Panel();
            this.layoutOrderDetailsHeader = new System.Windows.Forms.TableLayoutPanel();
            this.labelQuantityHeaderT = new System.Windows.Forms.Label();
            this.labelTableBookHeaderT = new System.Windows.Forms.Label();
            this.labelPriceHeaderT = new System.Windows.Forms.Label();
            this.labelOrderNumber = new System.Windows.Forms.Label();
            this.labelOrderNumberT = new System.Windows.Forms.Label();
            this.labelOrderStatus = new System.Windows.Forms.Label();
            this.panelOrder.SuspendLayout();
            this.layoutOrderDetailsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOrder
            // 
            this.panelOrder.Controls.Add(this.labelTotalAmount);
            this.panelOrder.Controls.Add(this.labelTotalAmountT);
            this.panelOrder.Controls.Add(this.labelOrderMessage);
            this.panelOrder.Controls.Add(this.panelOrderSlip);
            this.panelOrder.Controls.Add(this.layoutOrderDetailsHeader);
            this.panelOrder.Controls.Add(this.labelOrderNumber);
            this.panelOrder.Controls.Add(this.labelOrderNumberT);
            this.panelOrder.Controls.Add(this.labelOrderStatus);
            this.panelOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrder.Location = new System.Drawing.Point(0, 0);
            this.panelOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(735, 416);
            this.panelOrder.TabIndex = 1;
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelTotalAmount.Location = new System.Drawing.Point(555, 59);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(28, 17);
            this.labelTotalAmount.TabIndex = 11;
            this.labelTotalAmount.Text = "0.0";
            // 
            // labelTotalAmountT
            // 
            this.labelTotalAmountT.AutoSize = true;
            this.labelTotalAmountT.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalAmountT.ForeColor = System.Drawing.Color.DimGray;
            this.labelTotalAmountT.Location = new System.Drawing.Point(443, 59);
            this.labelTotalAmountT.Name = "labelTotalAmountT";
            this.labelTotalAmountT.Size = new System.Drawing.Size(91, 17);
            this.labelTotalAmountT.TabIndex = 10;
            this.labelTotalAmountT.Text = "Total Amount";
            // 
            // labelOrderMessage
            // 
            this.labelOrderMessage.AutoSize = true;
            this.labelOrderMessage.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelOrderMessage.Location = new System.Drawing.Point(15, 36);
            this.labelOrderMessage.Name = "labelOrderMessage";
            this.labelOrderMessage.Size = new System.Drawing.Size(61, 17);
            this.labelOrderMessage.TabIndex = 9;
            this.labelOrderMessage.Text = "message";
            // 
            // panelOrderSlip
            // 
            this.panelOrderSlip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOrderSlip.AutoScroll = true;
            this.panelOrderSlip.Location = new System.Drawing.Point(6, 129);
            this.panelOrderSlip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelOrderSlip.Name = "panelOrderSlip";
            this.panelOrderSlip.Size = new System.Drawing.Size(725, 271);
            this.panelOrderSlip.TabIndex = 8;
            // 
            // layoutOrderDetailsHeader
            // 
            this.layoutOrderDetailsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutOrderDetailsHeader.AutoScroll = true;
            this.layoutOrderDetailsHeader.ColumnCount = 3;
            this.layoutOrderDetailsHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.layoutOrderDetailsHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutOrderDetailsHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutOrderDetailsHeader.Controls.Add(this.labelQuantityHeaderT, 1, 0);
            this.layoutOrderDetailsHeader.Controls.Add(this.labelTableBookHeaderT, 0, 0);
            this.layoutOrderDetailsHeader.Controls.Add(this.labelPriceHeaderT, 2, 0);
            this.layoutOrderDetailsHeader.Location = new System.Drawing.Point(5, 98);
            this.layoutOrderDetailsHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutOrderDetailsHeader.Name = "layoutOrderDetailsHeader";
            this.layoutOrderDetailsHeader.RowCount = 1;
            this.layoutOrderDetailsHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutOrderDetailsHeader.Size = new System.Drawing.Size(726, 26);
            this.layoutOrderDetailsHeader.TabIndex = 7;
            // 
            // labelQuantityHeaderT
            // 
            this.labelQuantityHeaderT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuantityHeaderT.AutoSize = true;
            this.labelQuantityHeaderT.Location = new System.Drawing.Point(500, 6);
            this.labelQuantityHeaderT.Name = "labelQuantityHeaderT";
            this.labelQuantityHeaderT.Size = new System.Drawing.Size(49, 13);
            this.labelQuantityHeaderT.TabIndex = 4;
            this.labelQuantityHeaderT.Text = "Quantity";
            this.labelQuantityHeaderT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTableBookHeaderT
            // 
            this.labelTableBookHeaderT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTableBookHeaderT.AutoSize = true;
            this.labelTableBookHeaderT.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTableBookHeaderT.Location = new System.Drawing.Point(3, 6);
            this.labelTableBookHeaderT.Name = "labelTableBookHeaderT";
            this.labelTableBookHeaderT.Size = new System.Drawing.Size(30, 13);
            this.labelTableBookHeaderT.TabIndex = 0;
            this.labelTableBookHeaderT.Text = "Book";
            // 
            // labelPriceHeaderT
            // 
            this.labelPriceHeaderT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPriceHeaderT.AutoSize = true;
            this.labelPriceHeaderT.Location = new System.Drawing.Point(637, 6);
            this.labelPriceHeaderT.Name = "labelPriceHeaderT";
            this.labelPriceHeaderT.Size = new System.Drawing.Size(30, 13);
            this.labelPriceHeaderT.TabIndex = 3;
            this.labelPriceHeaderT.Text = "Price";
            // 
            // labelOrderNumber
            // 
            this.labelOrderNumber.AutoSize = true;
            this.labelOrderNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderNumber.ForeColor = System.Drawing.Color.Black;
            this.labelOrderNumber.Location = new System.Drawing.Point(96, 59);
            this.labelOrderNumber.Name = "labelOrderNumber";
            this.labelOrderNumber.Size = new System.Drawing.Size(45, 19);
            this.labelOrderNumber.TabIndex = 2;
            this.labelOrderNumber.Text = "1234";
            // 
            // labelOrderNumberT
            // 
            this.labelOrderNumberT.AutoSize = true;
            this.labelOrderNumberT.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderNumberT.ForeColor = System.Drawing.Color.DimGray;
            this.labelOrderNumberT.Location = new System.Drawing.Point(15, 59);
            this.labelOrderNumberT.Name = "labelOrderNumberT";
            this.labelOrderNumberT.Size = new System.Drawing.Size(67, 19);
            this.labelOrderNumberT.TabIndex = 1;
            this.labelOrderNumberT.Text = "Order #";
            // 
            // labelOrderStatus
            // 
            this.labelOrderStatus.AutoSize = true;
            this.labelOrderStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderStatus.Location = new System.Drawing.Point(15, 11);
            this.labelOrderStatus.Name = "labelOrderStatus";
            this.labelOrderStatus.Size = new System.Drawing.Size(98, 19);
            this.labelOrderStatus.TabIndex = 0;
            this.labelOrderStatus.Text = "Order Status";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 416);
            this.Controls.Add(this.panelOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            this.layoutOrderDetailsHeader.ResumeLayout(false);
            this.layoutOrderDetailsHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.Label labelOrderMessage;
        private System.Windows.Forms.Panel panelOrderSlip;
        private System.Windows.Forms.TableLayoutPanel layoutOrderDetailsHeader;
        private System.Windows.Forms.Label labelQuantityHeaderT;
        private System.Windows.Forms.Label labelTableBookHeaderT;
        private System.Windows.Forms.Label labelPriceHeaderT;
        private System.Windows.Forms.Label labelOrderNumber;
        private System.Windows.Forms.Label labelOrderNumberT;
        private System.Windows.Forms.Label labelOrderStatus;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.Label labelTotalAmountT;
    }
}