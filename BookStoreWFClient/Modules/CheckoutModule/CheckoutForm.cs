using System;
using System.Windows.Forms;
using BookStoreWFClient.Util;
using BookStoreWFClient.Model;


namespace BookStoreWFClient.Modules.CheckoutModule
{
    public partial class CheckoutForm : BasicForm
    {
        CheckoutController controller;
        
        public CheckoutForm()
        {
            InitializeComponent();
            InitializeEvents();
            controller = new CheckoutController(this);
        }

        private void DrawCOBooksItems()
        {
            panelCOBooksList.Controls.Clear();
            if (Global.Cart.CartItems == null)
            {
                ShowNoResultMessage();
                return;
            }
            int numberOfCartItems = Global.Cart.CartItems.Count;

            for (int i = 0; i < numberOfCartItems; i++)
            {
                panelCOBooksList.Controls.Add(CreateCOBookItem(Global.Cart.CartItems[i]));
            }
        }

        private Control CreateCOBookItem(CartItem drawingItem)
        {
            return DrawingSets.CreateHorizontalBookItem(drawingItem, panelCOBooksList, "CHECKOUT", EH_SELECTOR_VALUE_CHANGED);
        }

        private void InitializeEvents()
        {
            Load += new EventHandler(EH_FORM_LOAD);
            btnPlaceOrder.Click += new EventHandler(EH_BUTTON_CLICK_PLACE_ORDER);
        }

        private void EH_FORM_LOAD(object sender, EventArgs args)
        {
            // set culture info for this thread
            Culture.SetCultureInfo();
            // display the total amount
            labelCOTotalAmount.Text = controller.Total.ToString("C");
            // draw the cart itmes in the checkout list
            DrawCOBooksItems();
        }

        private void EH_SELECTOR_VALUE_CHANGED(object sender, EventArgs e)
        {
            NumericUpDown selector = (NumericUpDown)sender;
            CartItem changedItem = (CartItem)selector.Tag;
            int newQuantity = Convert.ToInt32(selector.Value);
            if (newQuantity == 0)
            {
                //remove the book item from checkout interface
                Controls.Remove(selector.Parent);
                selector.Parent.Dispose();
            }
            Global.CartForm.UpdateCartItem(changedItem, newQuantity);
            Global.MainForm.controller.CheckOut(Global.Cart, this);
        }

        private void EH_BUTTON_CLICK_PLACE_ORDER(object sender, EventArgs args)
        {
            controller.OpenOrderForm();
        }
    }
}
