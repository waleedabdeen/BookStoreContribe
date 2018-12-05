using BookStoreWFClient.Util;
using BookStoreWFClient.Modules.OrderModule;
using BookStoreWFClient.Model;

namespace BookStoreWFClient.Modules.CheckoutModule
{
    class CheckoutController
    {
        BasicForm form;

        public decimal Total{
            get
            {
                return CalculateTotal();
            }
        }

        public CheckoutController(BasicForm _form)
        {
            form = _form;
        }

        private decimal CalculateTotal()
        {
            decimal totalAmount = 0;
            for (int i = 0; i < Global.Cart.CartItems.Count; i++)
            {
                if (Global.Cart.CartItems[i].IsAvailable)
                {
                    totalAmount += Global.Cart.CartItems[i].Book.Price * Global.Cart.CartItems[i].Quantity;
                }
            }
            return totalAmount;
        }

        public void OpenOrderForm()
        {
            OrderForm orderForm = new OrderForm();
            orderForm.TopLevel = false;
            orderForm.Dock = System.Windows.Forms.DockStyle.Fill;
            Global.ContentArea.Controls.Clear();
            Global.ContentArea.Controls.Add(orderForm);
            orderForm.Show();
        }
    }
}
