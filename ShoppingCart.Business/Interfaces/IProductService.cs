using System.Collections.Generic;
using ShoppingCart.Model;

namespace ShoppingCart.Business
{
    public interface IProductService
    {
        List<Product> GetProducts();        
        int AddProduct(Product product);
        void DeleteProduct(int productid);
        void UpdateProduct(Product product);

    }
}
