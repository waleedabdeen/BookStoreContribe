using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Model;
using BookStoreWFClient.Util;

namespace BookStoreWFClient.Modules.CartModule
{
    public partial class CartForm : BasicForm
    {
        CartController controller;
        
        public CartForm()
        {
            InitializeComponent();
            InitializeEvents();
            listCartBooks.Items.Clear();
            if(Global.Cart != null && Global.Cart.CartItems.Count() > 0)
            {
                FillListCartFromCart();
            }
            Global.CartForm = this;
            controller = new CartController(this);
        }       

        public void AddItemToCartInterface(BookDTO book, int quantity)
        {
            CartItem addedCartItem = new CartItem();
            addedCartItem.Book = book;
            addedCartItem.Quantity = quantity;

            if (!string.IsNullOrEmpty(book.Id) && quantity > 0)
            {
                int foundIndex = -1;
                for (int i = 0; i < listCartBooks.Items.Count; i++)
                {
                    CartItem currentItem = (CartItem)listCartBooks.Items[i];
                    if (currentItem.Book.Id == addedCartItem.Book.Id)
                    {
                        foundIndex = i;
                        break;
                    }
                }
                if (foundIndex >= 0)
                {
                    CartItem updatedItem = (CartItem)listCartBooks.Items[foundIndex];
                    updatedItem.Quantity += addedCartItem.Quantity;
                    listCartBooks.Items[foundIndex] = updatedItem;
                }
                else
                {
                    listCartBooks.Items.Add(addedCartItem);
                }
            }
            controller.SyncCartObjectWithInterfaceList(listCartBooks.Items);
        }

        public void UpdateCartItem(CartItem changedItem, int quantity)
        {

            if (quantity == 0)
            {
                //remove the book item from the cart interface
                listCartBooks.Items.Remove(changedItem);
            }
            else
            {
                int changedItemIndex = listCartBooks.Items.IndexOf(changedItem);
                CartItem item = (CartItem) listCartBooks.Items[changedItemIndex];
                item.Quantity = quantity;
            }
            controller.SyncCartObjectWithInterfaceList(listCartBooks.Items);
        }

        public void EmptyCart()
        {
            listCartBooks.Items.Clear();
            controller.EmptyCart();
        }

        private void FillListCartFromCart()
        {
            foreach(CartItem cartItem in Global.Cart.CartItems)
            {
                listCartBooks.Items.Add(cartItem);
            }
        }
        private void InitializeEvents()
        {
            btnDeleteBooks.Click += new EventHandler(EH_BUTTON_CLICK_REMOVE_FROM_CART);
            btnCheckout.Click += new EventHandler(EH_BUTTON_CLICK_CHECKOUT);
        }

        private void EH_BUTTON_CLICK_REMOVE_FROM_CART(object sender, EventArgs e)
        {
            listCartBooks.CheckedItems.OfType<CartItem>().ToList().ForEach(listCartBooks.Items.Remove);
        }
        private void EH_BUTTON_CLICK_CHECKOUT(object sender, EventArgs e)
        {
            controller.CheckOut(listCartBooks.Items);
        }
    }
}
