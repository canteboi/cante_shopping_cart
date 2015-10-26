using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;
using Product = ShoppingCart.Model.Product;

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
