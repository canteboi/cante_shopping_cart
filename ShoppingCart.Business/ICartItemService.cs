using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;

namespace ShoppingCart.Business
{
    interface ICartItemService
    {
        List<CartItem> GetCartItems();
        int AddCartItem();
        void DeleteCartItem();
        void UpdateCartItem();
    }
}
