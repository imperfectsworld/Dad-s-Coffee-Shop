
using DAD_s_Coffee_Shop_Lab;
using System;
using System.ComponentModel.Design;
 List<Cart> SCart = new List<Cart>();
string filePath = "../../../coffee.txt";
  if (!File.Exists(filePath))
{
    StreamWriter tempCoffee = new StreamWriter(filePath);
    foreach (Coffee item in Coffee.products) 
        {
        tempCoffee.WriteLine(item.ToString()); 
        } 
    tempCoffee.Close();
}


Coffee.ListProducts();
Console.WriteLine("Enter the Menu(number /Coffee Name)"); 
string? selection = Console.ReadLine();
int input;

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
else if ((Coffee.products.Any(p=>p.Name.Equals(selection,StringComparison.OrdinalIgnoreCase))))
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