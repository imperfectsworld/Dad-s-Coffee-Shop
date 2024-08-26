using DAD_s_Coffee_Shop_Lab;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_coffeeProjectTest
{
    internal class Inventory
    {
        public Coffee Name { get; set; }
        public string Component { get; set; }
        public double Quantity { get; set; }
        public double Cost { get; set; }
        public Inventory(string component, double quantity, double cost)
        {
            Component = component;
            Quantity = quantity;
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
            new Inventory("cups", 30, 10.00),
            new Inventory("lids", 15, 10.00)
        };
        public override string ToString()
        {
            return String.Format("\t{0,30}\t {1,10}\t {2,15}\t", $"{Component}|", $"{Quantity}|", $"${Cost}|");
        }

        public static void ListInventory()
        {
            for (int i = 0; i < stock.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {stock[i]}");
            }
        }

        public static void DrinkConstructor(Coffee selected)
        {
            string sold = selected.ToString().ToLower();
            if (sold == "espresso")
            {
                Inventory.stock.Where(s => s.Component == "espresso beans")
                                    .Select(i =>
                                    {
                                        i.Quantity -= 1;
                                        return new
                                        {
                                            Quantity = i.Quantity
                                        };
                                    });
                Inventory.stock.Where(s => s.Component == "cups")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
                Inventory.stock.Where(s => s.Component == "lids")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
            }
            else if (sold == "cappuccino")
            {
                Inventory.stock.Where(s => s.Component == "espresso beans")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "2% milk")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "cups")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
                Inventory.stock.Where(s => s.Component == "lids")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
            }
            else if (sold == "latte")
            {
                Inventory.stock.Where(s => s.Component == "espresso beans")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "2% milk")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "cups")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
                Inventory.stock.Where(s => s.Component == "lids")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
            }
            else if (sold == "mocha")
            {
                Inventory.stock.Where(s => s.Component == "espresso beans")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "2% milk")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "chocolate syrup")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "cups")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
                Inventory.stock.Where(s => s.Component == "lids")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
            }
            else if (sold == "machiato")
            {
                Inventory.stock.Where(s => s.Component == "espresso beans")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "2% milk")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "cups")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
                Inventory.stock.Where(s => s.Component == "lids")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
            }
            else if (sold == "americano")
            {
                Inventory.stock.Where(s => s.Component == "espresso beans")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "2% milk")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "cups")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
                Inventory.stock.Where(s => s.Component == "lids")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
            }
            else if (sold == "chair latte")
            {
                Inventory.stock.Where(s => s.Component == "chai")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "2% milk")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "cups")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
                Inventory.stock.Where(s => s.Component == "lids")
                    .Select(i =>
                    {
                        i.Quantity -= 1;
                        return new
                        {
                            Quantity = i.Quantity
                        };
                    });
            }
            else if (sold == "green tea")
            {
                Inventory.stock.Where(s => s.Component == "ceremony grade matcha")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "cups")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "lids")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
            }
            else if (sold == "herbal tea")
            {
                Inventory.stock.Where(s => s.Component == "loose leaf herbal collection")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "cups")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "lids")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
            }
            else if (sold == "hot chocolate")
            {
                Inventory.stock.Where(s => s.Component == "swiss hot chocolate powder")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
                Inventory.stock.Where(s => s.Component == "2% milk")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "whipped cream")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "cups")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "lids")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
            }
            else if (sold == "iced coffee")
            {
                Inventory.stock.Where(s => s.Component == "refrigerated drip coffee")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "cups")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "lids")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
            }
            else if (sold == "cold brew")
            {
                Inventory.stock.Where(s => s.Component == "in-house cold brew concentrate")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "cups")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "lids")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
            }
            else if (sold == "iced tea")
            {
                Inventory.stock.Where(s => s.Component == "chilled in-house black tea")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "cups")
                   .Select(i =>
                   {
                       i.Quantity -= 1;
                       return new
                       {
                           Quantity = i.Quantity
                       };
                   });
                Inventory.stock.Where(s => s.Component == "lids")
                                   .Select(i =>
                                   {
                                       i.Quantity -= 1;
                                       return new
                                       {
                                           Quantity = i.Quantity
                                       };
                                   });
            }
        }
    }
}
