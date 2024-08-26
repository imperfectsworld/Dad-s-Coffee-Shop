using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace DAD_s_Coffee_Shop_Lab
{
    internal class Coffee
    {

        //properties
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        //constructor

        public Coffee(string _name, string _category, string _description, double _price)
        {
            Name = _name;
            Category = _category;
            Description = _description;
            Price = _price;
        }

        //methods

    public static List<Coffee> products = new List<Coffee> {new Coffee("Espresso", "Coffee", "Strong, black coffee", 2.50),
        new Coffee("Cappuccino", "Coffee", "Espresso with steamed milk and foam", 3.75),
        new Coffee("Latte", "Coffee", "Espresso with steamed milk", 3.50),
        new Coffee("Mocha", "Coffee", "Espresso with chocolate and steamed milk", 4.00),
        new Coffee("Macchiato", "Coffee", "Espresso with a dollop of foam", 3.00),
        new Coffee("Americano", "Coffee", "Espresso with hot water", 2.75),
        new Coffee("Chai Latte", "Tea", "Spiced tea with steamed milk", 3.25),
        new Coffee("Green Tea", "Tea", "Refreshing and healthy green tea", 2.25),
        new Coffee("Herbal Tea", "Tea", "Caffeine-free herbal infusion", 2.50),
        new Coffee("Hot Chocolate", "Hot Beverage", "Rich chocolate with steamed milk", 3.00),
        new Coffee("Iced Coffee", "Iced Coffee Beverage", "Chilled house-blend coffee with ice", 3.00),
        new Coffee("Cold Brew", "Iced Coffee Beverage", "House blend grounds soaked for 48 hrs", 4.50),
        new Coffee("Iced Tea", "Iced Tea Beverage", "Chilled black tea with ice", 2.50)
    };
        
        public override string ToString()
        {

            return String.Format("\t{0,20} {1,22}\t {2,45}\t {3,10}\t", $"{Name}|", $" {Category}|", $" {Description}|", $" ${Price}|");
        }


        public static void ListProducts()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < products.Count; i++)
            {
                
                Console.WriteLine($"{i + 1}. {products[i]}");
            }
            Console.ResetColor();
        }


    }
}