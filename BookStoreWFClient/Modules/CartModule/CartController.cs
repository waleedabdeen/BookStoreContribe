using System.Windows.Forms;
using BookStoreWFClient.Model;
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
