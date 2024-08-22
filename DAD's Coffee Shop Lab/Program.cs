
using DAD_s_Coffee_Shop_Lab;

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
StreamWriter tempCoffee = new StreamWriter("coffee.txt");
  if (!File.Exists(filePath))
{
    
     foreach (Coffee item in Coffee.products) 
        {
        tempCoffee.WriteLine(item.ToString()); 
        } 
    tempCoffee.Close();
}


Coffee.ListProducts();

