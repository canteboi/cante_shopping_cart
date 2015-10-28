using System.Collections.Generic;
using ShoppingCart.Model;
using DbCartItem = ShoppingCart.Data.CartItem;

namespace ShoppingCart.Business
{
    public interface ICartItemService
    {
        List<CartItem> GetCartItems(int customerId);
        int AddCartItem(CartItem cartItem);
        void DeleteCartItem(int customerId);
        void UpdateCartItem(CartItem cartItem);
    }
}
