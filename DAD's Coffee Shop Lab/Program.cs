
using DAD_s_Coffee_Shop_Lab;
using System.Xml.Serialization;

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
//Menu print
Coffee.ListProducts();

Console.WriteLine("Please select which item you would like to order. (Use number)");

//input order
string selection = Console.ReadLine();
int input;
if(int.TryParse(Console.ReadLine(), out input))
{
    while (input > Coffee.products.Count || input < 1)
    {
        Console.WriteLine("Enter the valid input");
    }
    input--;
    //return order & print
    Console.WriteLine($"{Coffee.products[input]}");
}
/*else if(Coffee.products.Contains(selection))
{

}*/

