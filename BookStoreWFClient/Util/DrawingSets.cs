using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Model;

namespace BookStoreWFClient.Util
{
    class DrawingSets
    {
        public static bool InvokeRequired { get; private set; }

        public static TableLayoutPanel CreateHorizontalBookItem(CartItem drawingItem, Panel container, string listType, EventHandler selectorEvent)
        {
            int tblLayoutHeight = 50;
            int tblLayoutWidth = container.Width;
            int tblLayoutX = 0;
            int tblLayoutY = (container.Controls.Count * tblLayoutHeight) + (int)(container.Controls.Count * tblLayoutHeight * 0.1);

            //Setting culture info
            Culture.SetCultureInfo();

            //Create title label
            Label titleLabel = new Label();
            titleLabel.Padding = new Padding(5, 5, 5, 5);
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLabel.Text = drawingItem.Book.Title + " - " + drawingItem.Book.Author;
            if (!drawingItem.IsAvailable)
            {
                if (listType == "CHECKOUT")
                {
                    titleLabel.ForeColor = Color.Red;
                    titleLabel.Text += " (Not Available)";
                }
                else if (listType == "ORDER")
                {
                    titleLabel.ForeColor = Color.Gray;
                    titleLabel.Text += " (Not Ordered)";
                }
            }

            //Create quantity selector
            NumericUpDown quantitySelector = new NumericUpDown();
            quantitySelector.AutoSize = true;
            quantitySelector.BackColor = Color.White;
            quantitySelector.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantitySelector.Padding = new Padding(5, 5, 5, 5);
            quantitySelector.Value = drawingItem.Quantity;
            quantitySelector.Anchor = AnchorStyles.Top;
            quantitySelector.Tag = drawingItem;
            if (listType == "CHECKOUT")
            {
                quantitySelector.ValueChanged += new EventHandler(selectorEvent);
            }
            else if (listType == "ORDER")
            {
                quantitySelector.Enabled = false;
            }

            //Create price label
            Label priceLabel = new Label();
            priceLabel.AutoSize = true;
            priceLabel.BackColor = Color.Transparent;
            priceLabel.Dock = DockStyle.Fill;
            priceLabel.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            priceLabel.Margin = new Padding(0);
            priceLabel.Padding = new Padding(5, 5, 5, 5);
            priceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            if (drawingItem.IsAvailable)
            {
                priceLabel.Text = drawingItem.Book.Price.ToString("C");
            }
            else
            {
                if (listType == "CHECKOUT")
                {
                    priceLabel.Text = drawingItem.Book.Price.ToString("C");
                }
                else if (listType == "ORDER")
                {
                    priceLabel.Text = "-";
                }
            }

            //Create TableLayout
            TableLayoutPanel tblLayoutHandler = new TableLayoutPanel();
            tblLayoutHandler.BackColor = Color.White;
            //tblLayoutHandler.Dock = DockStyle.Fill;
            tblLayoutHandler.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tblLayoutHandler.Location = new Point(tblLayoutX, tblLayoutY);
            tblLayoutHandler.Size = new Size(tblLayoutWidth, tblLayoutHeight);
            tblLayoutHandler.Margin = new Padding(10);
            tblLayoutHandler.RowCount = 1;
            tblLayoutHandler.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tblLayoutHandler.ColumnCount = 3;
            tblLayoutHandler.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tblLayoutHandler.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tblLayoutHandler.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            //add the control to the table layout panel
            tblLayoutHandler.Controls.Add(titleLabel, 0, 0);
            tblLayoutHandler.Controls.Add(quantitySelector, 1, 0);
            tblLayoutHandler.Controls.Add(priceLabel, 2, 0);

            return tblLayoutHandler;
        }
    }
}
