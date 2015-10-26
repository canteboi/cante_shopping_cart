using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Model
{
    public  class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Firstname { get; set; }
        public string Lastame { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public System.DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
