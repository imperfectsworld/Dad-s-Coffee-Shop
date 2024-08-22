using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAD_s_Coffee_Shop_Lab
{
    internal class Cart:Coffee
    {
        public int Quantity { get; set; }


        public Cart(string _name, string _category, string _description, double _price,int _quantity) :base( _name, _category, _description, _price)
        {
            Quantity = _quantity;
        }
        
        public void ShoppingCart(List<Coffee> i )
        {
            Console.WriteLine("Enter the quantity:");
            int quantity = int.Parse(Console.ReadLine());
           // SCart.Add();

           //SCart.Add(i);
        }
        public override string ToString()
        {
            return String.Format("{0,15} {3,10}", $"{Name}|", $"{Price}|");
        }
    }
}
