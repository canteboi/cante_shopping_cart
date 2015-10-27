using System.Collections.Generic;
using DbCartItem = ShoppingCart.Data.CartItem;
using CartItem = ShoppingCart.Model.CartItem;

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
