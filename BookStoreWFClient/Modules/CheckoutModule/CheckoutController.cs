using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWFClient.Model;
using BookStoreWFClient.Util;
using BookStoreWFClient.Modules.ApiModule;
using BookStoreWFClient.Modules.OrderModule;

namespace BookStoreWFClient.Modules.CheckoutModule
{
    class CheckoutController
    {
        public decimal Total{
            get
            {
                return CalculateTotal();
            }
        }

        public CheckoutController()
        {
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
