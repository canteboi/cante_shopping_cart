using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;

namespace ShoppingCart.Business
{
    interface IProductService
    {
        List<Product> GetProducts();
        int AddProduct();
        void DeleteProduct();
        void UpdateProduct();

    }
}
