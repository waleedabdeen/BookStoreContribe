using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreWFClient.Model;
using BookStoreWFClient.Modules.ApiModule;
using BookStoreWFClient.Util;

namespace BookStoreWFClient.Modules.CartModule
{
    class CartController
    {
        BasicForm form;
        public CartController(BasicForm _form)
        {
            form = _form;
        }
        public void CheckOut(CheckedListBox.ObjectCollection listItems)
        {
            SyncCartObjectWithInterfaceList(listItems);
            Global.MainForm.controller.CheckOut(Global.Cart, form);
        }

        public void SyncCartObjectWithInterfaceList(CheckedListBox.ObjectCollection listItems)
        {
            Cart cart = new Cart();
            cart.Id = "TheCartId";
            foreach (CartItem item in listItems)
            {
                cart.CartItems.Add(item);
            }
            Global.Cart = cart;
        }

        public void EmptyCart()
        {
            Global.Cart = null;
        }
    }
}
