﻿
using DAD_s_Coffee_Shop_Lab;
using System.Xml.Serialization;
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
}
    
else if ((Coffee.products.Any(p => p.Name.Equals(selection, StringComparison.OrdinalIgnoreCase))))
{
    Coffee selected = Coffee.products.Find(p => p.Name.Equals(selection, StringComparison.OrdinalIgnoreCase));
    Console.WriteLine($"{selected}");
    Console.WriteLine("Enter the Quantity:");
    int quantity = int.Parse(Console.ReadLine());
    //SCart.Add(selected).ToList();
}
else
{
    Console.WriteLine("InValid input ");
}