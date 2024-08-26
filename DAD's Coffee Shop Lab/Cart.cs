using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAD_s_Coffee_Shop_Lab
{
    internal class Cart
    {
        public int Quantity { get; set; }
        public Coffee Product { get; set; }

        public double Rate { get; set; }

        
        public Cart(int _quantity, Coffee _product, double _rate)
        {
            Quantity = _quantity;
            Product = _product;
            Rate = _rate;

        }

        public static List<string> paymentMethod = new()
    {
        "cash","check","credit"
    };
        public static List <Cart> orderList = new List<Cart>();

        public override string ToString()
        {
            return String.Format("{0,-20} {1,20\t} {2,20\t} {3,20\t}", $"{Product.Name}|", $"{Product.Price}| , {Quantity}|, {Rate}");
        }





    }
}
