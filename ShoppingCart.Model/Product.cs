using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Model
{
    public class Product
    {
        public int Productid { get; set; }
        public string Productname { get; set; }
        public string Header { get; set; }
        public string Shortdesc { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Imagename { get; set; }
        public string Status { get; set; }
        public decimal Unitprice { get; set; }
        public int Quantity { get; set; }
        public int Subtract { get; set; }
        public int SortOrder { get; set; }
        public int Categoryid { get; set; }
        public System.DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
