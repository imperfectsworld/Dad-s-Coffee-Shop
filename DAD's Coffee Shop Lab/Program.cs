
using DAD_s_Coffee_Shop_Lab;
using System;
using System.ComponentModel;
using System.Xml.Serialization;
using StaticLecture;
List<Cart> SCart = new List<Cart>();
string filePath = "../../../coffee.txt";
Console.WriteLine("Hello, World!");
/*


//if file doesn't exist
if (!File.Exists(filePath))
{
   
    //name|grade|age
    tempWriter.WriteLine("Justin Jones|12|18");
    tempWriter.WriteLine("Ethan Thomas|10|16");
   
}


*/

if (!File.Exists(filePath))
{
    StreamWriter tempCoffee = new StreamWriter(filePath);
    foreach (Coffee item in Coffee.products)
    {
        tempCoffee.WriteLine(item.ToString());
    }
    tempCoffee.Close();
}
bool orderProgram = true;
while (orderProgram)
{
    //Menu print
    Coffee.ListProducts();
    Console.WriteLine("Enter the Menu(number /Coffee Name)");
    string? selection = Console.ReadLine();
    int input;
    //input order
    if (int.TryParse(selection, out input))
    {
        while (input > Coffee.products.Count || input < 1)
        {
            Console.WriteLine("Enter the valid input");
            input = int.Parse(Console.ReadLine());
        }
        input--;
        Console.WriteLine($"{Coffee.products[input]}");
        Coffee selected = Coffee.products[input];
        DisplayCart(selected);
    }

    else if ((Coffee.products.Any(p => p.Name.Equals(selection, StringComparison.OrdinalIgnoreCase))))
    {
        Coffee selected = Coffee.products.Find(p => p.Name.Equals(selection, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"{selected}");
        DisplayCart(selected);

    }
    else
    {
        Console.WriteLine("InValid input ");
        continue;
    }
    orderProgram = Validator.GetContinue("Would you like to add another item to your order?", "yes", "no");
    Console.Clear();
    if (orderProgram == false)
    {
        Console.Clear();
        GetTotal();

    }
}

static void Payment()

static void GetTotal()
{
    double total = 0;
    double tax = 0.06;
    Console.WriteLine("DAD's Coffee Roasters Cafe");
    Console.WriteLine("================================");
    Console.WriteLine("Name".PadRight(16) + "Quantity\t" + "Subtotal");
    foreach (Cart t in Cart.orderList)
    {
        total += t.Rate;
        Console.WriteLine($"{t.Product.Name.PadRight(16)}" + $"{t.Quantity}\t\t{t.Rate}");
    }
    Console.WriteLine($"\nSubtotal: ${total}");
    Console.WriteLine($"Sales Tax: {total * tax}");
    Console.WriteLine($"\nTotal: {total + (total * tax)}");
}

    static void DisplayCart(Coffee order)
    {
        Console.WriteLine("Enter the Quantity:");
        int quantity = Validator.GetPositiveInputInt();
        double total = order.Price * quantity;
        Cart.orderList.Add(new Cart(quantity, order, total));
        Console.WriteLine("================================");
        Console.WriteLine("Name".PadRight(16) + "Quantity\t" + "Subtotal");
        foreach (Cart o in Cart.orderList)
        {

            Console.WriteLine($"{o.Product.Name.PadRight(16)} {o.Quantity}\t\t{o.Rate}");


        }

    }
