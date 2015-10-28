using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;
using ShoppingCart.Model;
using DbCartItem = ShoppingCart.Data.CartItem;
using CartItem = ShoppingCart.Model.CartItem;
using DbProduct = ShoppingCart.Data.Product;
using Product = ShoppingCart.Model.Product;

namespace ShoppingCart.Business
{
    public class CartItemService : ICartItemService
    {
        private readonly ShoppingCartDbEntities _dbEntities;

        public CartItemService()
        {
            _dbEntities = new ShoppingCartDbEntities();
        }

        public List<CartItem> GetCartItems(int customerId)
        {
            var dbcartitems = _dbEntities.CartItems.Where(x => x.customer_id == customerId);
            var cartitems = dbcartitems.ToList().ConvertAll(x => new CartItem()
            {
                CartId = x.cart_id,
                DateAdded = x.date_added,
                DateModified = x.date_modified,
                ProductId = x.product_id,
                Quanity = x.quanity,
                Product = new Product()
                                {
                                    Productname = x.Product.productname,
                                    Productid = x.product_id,
                                    Image = x.Product.image,
                                    Imagename = x.Product.imagename,
                                    Unitprice = x.Product.unitprice
                                }
            });

            return cartitems;

        }

        public int AddCartItem(CartItem cartItem)
        {
            try
            {
                var dbcartitem = new DbCartItem()
                {
                    product_id = cartItem.ProductId,
                    quanity = cartItem.Quanity
                };

                dbcartitem = _dbEntities.CartItems.Add(dbcartitem);
                _dbEntities.SaveChanges();

                return dbcartitem.cart_id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteCartItem(int customerId)
        {
            var dbcartitem = _dbEntities.CartItems.SingleOrDefault(x => x.cart_id == customerId);

            if (dbcartitem == null)
            {
                throw new ObjectNotFoundException(string.Format(" Cart for customer Id of :{0} was not found", customerId));
            }

            try
            {
                _dbEntities.CartItems.Remove(dbcartitem);
                _dbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            var dbcartitem = _dbEntities.CartItems.SingleOrDefault(x => x.cart_id == cartItem.CartId);

            if (dbcartitem == null)
            {
                throw new ObjectNotFoundException(string.Format(" Cart Id of :{0} was not found", cartItem.CartId));
            }

            try
            {
                dbcartitem.product_id = cartItem.ProductId;
                dbcartitem.quanity = cartItem.Quanity;
                dbcartitem.date_modified = DateTime.Now;


                _dbEntities.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
