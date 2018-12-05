using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Model;
using BookStoreWFClient.Util;

namespace BookStoreWFClient.Modules.OrderModule
{
    public partial class OrderForm : Form
    {
        OrderController controller;
        OrderDetailsDTO orderDetailsDTO;
        public OrderForm()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private async Task<OrderDetailsDTO> InitializeOrder()
        {
            controller = new OrderController();
            return orderDetailsDTO = await controller.PlaceOrder();
        }
       
        private void DrawOrderDetails()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                if (orderDetailsDTO == null || orderDetailsDTO.OrderItemsDTO.Count() == 0)
                {
                    PrepareOrderInterface(orderDetailsDTO, false);
                }
                else
                {
                    PrepareOrderInterface(orderDetailsDTO, true);
                    Global.CartForm.EmptyCart();
                }
            }));
        }

        private void PrepareOrderInterface(OrderDetailsDTO orderDetailsDTO, bool isOK)
        {
            if (!isOK)
            {
                labelOrderNumber.Text = "";
                labelOrderStatus.Text = "Error creating order!";
                labelOrderStatus.ForeColor = Color.Red;
                labelOrderMessage.Text = "";
                labelTotalAmount.Text = "0";
                panelOrderSlip.Hide();
                layoutOrderDetailsHeader.Hide();
            }
            else
            {
                Culture.SetCultureInfo();
                labelOrderNumber.Text = orderDetailsDTO.Id;
                labelOrderStatus.Text = "Order " + orderDetailsDTO.Status.ToString();
                labelOrderStatus.ForeColor = Color.MediumSeaGreen;
                labelTotalAmount.Text = orderDetailsDTO.TotalAmount.ToString("C");

                if (orderDetailsDTO.OrderItemsDTO.Count() == Global.Cart.CartItems.Count())
                {
                    labelOrderMessage.Text = "All items were ordered";
                }
                else
                {
                    labelOrderMessage.Text = "Some items were not orderd!";
                }
                panelOrderSlip.Show();
                layoutOrderDetailsHeader.Show();
                panelOrderSlip.Controls.Clear();
                for (int i = 0; i < Global.Cart.CartItems.Count; i++)
                {
                    panelOrderSlip.Controls.Add(CreateOrderBookItem(Global.Cart.CartItems[i]));
                }
            }
        }

        private Control CreateOrderBookItem(CartItem drawingItem)
        {
            return DrawingSets.CreateHorizontalBookItem(drawingItem, panelOrderSlip, "ORDER", null);
        }

        private void InitializeEvents()
        {
            this.Load += new EventHandler(EH_FORM_LOAD);
        }

        private async void EH_FORM_LOAD(object sedner, EventArgs args)
        {
            await InitializeOrder().ContinueWith((tast)=> {
                DrawOrderDetails();
            });
            
        }
    }
}
