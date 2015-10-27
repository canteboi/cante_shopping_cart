using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;
using DbProduct = ShoppingCart.Data.Product;
using Product = ShoppingCart.Model.Product;

namespace ShoppingCart.Business
{
    public class ProductService : IProductService
    {
        private readonly ShoppingCartDbEntities _dbEntities;

        public ProductService()
        {
            _dbEntities = new ShoppingCartDbEntities();
        }

        public List<Product> GetProducts()
        {
            var dbproducts = _dbEntities.Products;
            var products = dbproducts.ToList().ConvertAll(x => new Product()
            {
                Productid = x.productid,
                Categoryid = x.categoryid,
                DateAdded = x.date_added,
                DateModified = x.date_modified,
                Description = x.description,
                Header = x.header,
                Image = x.image,
                Imagename = x.imagename,
                Productname = x.productname,
                Quantity = x.quantity,
                Subtract = x.subtract,
                SortOrder = x.sort_order,
                Shortdesc = x.shortdesc,
                Status = x.status,
                Unitprice = x.unitprice
            });

            return products;
        }

        public int AddProduct(Product product)
        {
            try
            {
                var dbproduct = new DbProduct()
                {
                    categoryid = product.Categoryid,
                    date_modified = DateTime.Now,
                    description = product.Description,
                    header = product.Header,
                    image = product.Image,
                    imagename = product.Imagename,
                    productname = product.Productname,
                    quantity = product.Quantity,
                    subtract = 0,
                    sort_order = product.SortOrder,
                    shortdesc = product.Shortdesc,
                    status = product.Status,
                    unitprice = product.Unitprice
                };

                dbproduct = _dbEntities.Products.Add(dbproduct);
                _dbEntities.SaveChanges();

                return dbproduct.productid;
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

        public void DeleteProduct(int productid)
        {
            var dbproduct = _dbEntities.Products.SingleOrDefault(x => x.productid == productid);

            if (dbproduct == null)
            {
                throw new ObjectNotFoundException(string.Format(" Product Id of :{0} was not found", productid));
            }

            try
            {
                _dbEntities.Products.Remove(dbproduct);
                _dbEntities.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }

        }

        public void UpdateProduct(Product product)
        {

            var dbproduct = _dbEntities.Products.SingleOrDefault(x => x.productid == product.Productid);

            if (dbproduct == null)
            {
                throw new ObjectNotFoundException(string.Format(" Product Id of :{0} was not found", product.Productid));
            }

            try
            {
                dbproduct.categoryid = product.Categoryid;
                dbproduct.date_modified = DateTime.Now;
                dbproduct.description = product.Description;
                dbproduct.header = product.Header;
                dbproduct.image = product.Image;
                dbproduct.imagename = product.Imagename;
                dbproduct.productname = product.Productname;
                dbproduct.quantity = product.Quantity;
                dbproduct.subtract = product.Subtract;
                dbproduct.sort_order = product.SortOrder;
                dbproduct.shortdesc = product.Shortdesc;
                dbproduct.status = product.Status;
                dbproduct.unitprice = product.Unitprice;

                _dbEntities.SaveChanges();

            }
            catch (Exception)
            {
                
                throw;
            }

        }

    }
}
