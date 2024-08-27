using DAD_s_Coffee_Shop_Lab;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Workshop_coffeeProjectTest;

namespace Workshop_coffeeProjectTest
{
    internal class Inventory
    {
        public Coffee Name { get; set; }
        public string Component { get; set; }
        public double Backstock { get; set; }
        public double Cost { get; set; }
        public Inventory(string component, double backstock, double cost)
        {
            Component = component;
            Backstock = backstock;
            Cost = cost;
        }
        public static List<Inventory> stock = new List<Inventory>
        {
            new Inventory("espresso beans", 40, 36.00),
            new Inventory("dark roast beans", 20, 34.00),
            new Inventory("medium roast beans", 20, 32.00),
            new Inventory("light roast beans", 40, 30.00),
            new Inventory("cold brew concentrate", 20, 38.00),
            new Inventory("refrigerated drip coffee", 20, 15.00),
            new Inventory("2% milk", 18.93, 3.00),
            new Inventory("skim milk", 5, 2.50),
            new Inventory("whole creamer", 10, 3.50),
            new Inventory("almond milk", 5, 2.50),
            new Inventory("oat milk", 5, 2.50),
            new Inventory("chai concentrate", 10, 15.00),
            new Inventory("ceremony grade matcha", 10, 35.00),
            new Inventory("loose leaf herbal collection", 15, 12.00),
            new Inventory("chilled in-house black tea", 10, 12.00),
            new Inventory("swiss hot chocolate powder", 50, 10.00),
            new Inventory("chocolate syrup", 50, 10.0),
            new Inventory("whipped cream", 5, 10.00),
            new Inventory("cups", 100, 10.00),
            new Inventory("lids", 100, 10.00)
        };
        public override string ToString()
        {
            return String.Format("\t{0,30}\t {1,10}\t {2,15}\t", $"{Component}|", $"{Backstock}|", $"${Cost}|");
        }

        public static void ListInventory()
        {
            for (int i = 0; i < stock.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {stock[i]}");
            }
        }

        public static void DrinkConstructor(Coffee selected, List<Coffee> products, List<Inventory> stock, int quantity)
        {
            string sold = "";
            foreach (Coffee item in products)
            {
                if (selected.Name == item.Name)
                {
                    sold = item.Name.ToLower();
                }
            }
            for (int i = 0; i < quantity; i++)
            {
                if (sold == "espresso")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "espresso beans").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "cappuccino")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "espresso beans").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "2% milk").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "latte")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "espresso beans").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "2% milk").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "mocha")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "espresso beans").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "2% milk").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "chocolate syrup").Backstock--;
                }
                else if (sold == "macchiato")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "espresso beans").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "2% milk").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "americano")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "espresso beans").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "chai latte")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "chai concentrate").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "2% milk").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "green tea")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "ceremony grade matcha").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "herbal tea")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "loose leaf herbal collection").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "hot chocolate")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "swiss hot chocolate powder").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "2% milk").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "iced coffee")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "refigerated drip coffee").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "cold brew")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "in-house cold brew concentrate").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
                else if (sold == "iced tea")
                {
                    Inventory.stock.FirstOrDefault(s => s.Component == "chilled in-house black tea").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "cups").Backstock--;
                    Inventory.stock.FirstOrDefault(s => s.Component == "lids").Backstock--;
                }
            }
        }
    }
}