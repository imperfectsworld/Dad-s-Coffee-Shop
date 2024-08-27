
using DAD_s_Coffee_Shop_Lab;
using System;
using System.ComponentModel;
using System.Xml.Serialization;
using StaticLecture;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Net.WebSockets;
using WMPLib;
using Workshop_coffeeProjectTest;



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


bool orderProgram = true;
EmployeeLogin();
while (orderProgram)
{
    
    WindowsMediaPlayer player = new WindowsMediaPlayer();
    player.URL = @"C:\\Users\\imper\\source\\repos\\DAD's Coffee Shop Lab\\DAD's Coffee Shop Lab\\bin\\Debug\\net8.0\\Ambient2.wav\";
    player.controls.play();
    
    
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("DAD's Coffee Roasters Cafe");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("=====================================================================================================================");
    Console.ResetColor();
    //Menu print
    Coffee.ListProducts();
    Console.WriteLine("");
    Console.WriteLine("Enter the Menu(number /Coffee Name)");
    string? selection = Console.ReadLine();
    int input;

           
        //input order
        if (int.TryParse(selection, out input))
        {
            while (input > Coffee.products.Count || input < 1)
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the valid input");
            Console.ResetColor();
                input = int.Parse(Console.ReadLine());
            }
            input--;
            Console.WriteLine($"{Coffee.products[input]}");
            Coffee selected = Coffee.products[input];
            Inventory.DrinkConstructor(selected, Coffee.products, Inventory.stock);
            DisplayCart(selected);
        }

        else if ((Coffee.products.Any(p => p.Name.Equals(selection, StringComparison.OrdinalIgnoreCase))))
        {
            Coffee selected = Coffee.products.Find(p => p.Name.Equals(selection, StringComparison.OrdinalIgnoreCase));
            Inventory.DrinkConstructor(selected,Coffee.products, Inventory.stock);
            Console.WriteLine($"{selected}");
            DisplayCart(selected);

        }
    else
        {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("InValid input ");
        Console.ResetColor();
        Console.Clear();
            continue;
        }
    Console.ForegroundColor = ConsoleColor.Blue;
    orderProgram = StaticLecture.Validator.GetContinue("Would you like to add another item to your order?", "yes", "no");
    Console.ResetColor();
        Console.Clear();
        if (orderProgram == false)
        {
            Console.Clear();
            (double finalTotal, double tip) = GetTotal();
            ChoosePayment(finalTotal, tip);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Thank you for your patronage! Dont be a stranger! :)");
        Console.ResetColor();
       // player.controls.stop();
        Console.WriteLine("New customer: press ENTER.");
            Console.ReadLine();
            Console.Clear();
            
         EmployeeLogin();
        Cart.orderList.Clear();
        orderProgram = true;

        }
    }



static void ChoosePayment(double pay,double tip)
{
    int index = 0;
    string choice ="";
    double cash = 0;
    double balance = 0;
    bool IsValid = true;
    bool runPayment = true;
    bool runProgram = true;
    string checkNum="";
    string cardNum = "";
    string expiration;
    string cvv;
  

    foreach (string s in Cart.paymentMethod)
    {

        Console.WriteLine($"{index+1}. {s}");
        index++;
    }

    while (runProgram)
    {
        while (runPayment)
        {
            string paySelect = Console.ReadLine().ToLower().Trim();
            if (int.TryParse(paySelect, out int userInput) && userInput <= Cart.paymentMethod.Count && userInput > 0)
            {

                //while (userInput > Cart.paymentMethod.Count || userInput < 0)
                //{
                //    Console.WriteLine("Please enter a valid input");
                //    paySelect = Console.ReadLine().ToLower().Trim();

                //}
                userInput--;
                choice = Cart.paymentMethod[userInput];
                // Console.WriteLine(choice);
                runPayment = false;
            }
            else if (Cart.paymentMethod.Any(p => p.Equals(paySelect, StringComparison.OrdinalIgnoreCase)))
            {
                choice = paySelect;
                runPayment = false;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input. Please enter a valid payment method.");
                Console.ResetColor();
                continue;
            }
        }
        if (choice == "cash")
        {
            double total = 0;
            while (IsValid)
            {
                Console.Write("Enter the amount: $");
                cash = StaticLecture.Validator.GetPositiveInputDouble();
                total += cash;
                balance = total - pay;
                if (balance < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You still owe {Math.Abs(Math.Round(balance, 2))} Please enter the amount:");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Your Change:${Math.Round(balance, 2)}");
                    IsValid = false;
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your Change:${Math.Round(balance, 2)}. Hit ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Your Change: ${Math.Round(balance, 2)}");
            Console.ResetColor();
            DisplayReceipt(tip);
            runProgram = false;
        }
    
        else if (choice == "check")
        {
            string pattern = @"^[A-Z]{0,3}\d{8,12}[A-Z]{0,3}$";
            Console.WriteLine("Enter the Check Number:");
            while (IsValid)
            {
                
                checkNum = Console.ReadLine();
                Regex regex = new Regex(pattern);
                if (Regex.IsMatch(checkNum, pattern))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Check accepted!");
                    Console.ResetColor();
                    IsValid = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid check Number:");
                    Console.ResetColor();
                    IsValid = true;
                }
            }
            Console.Clear();
            DisplayReceipt(tip);
            string last = checkNum.Substring(checkNum.Length - 4);
            Console.WriteLine($"Check Number : ****{last}");
            runProgram = false;
           

        }
        else if (choice == "credit")
        {
            
            string pattern = @"^\d{4}[- ]?\d{4}[- ]?\d{4}[- ]?\d{4}(\d{1,3})?$";
            string datePattern = @"^(0[1-9]|1[0-2])\/?([0-9]{2}|[0-9]{4})$";
            string cvvPattern = @"^\d{3,4}$";
            Console.WriteLine("Enter the credit card Number:");
            while (IsValid)
            {
                
                cardNum = Console.ReadLine();
                Console.WriteLine("Enter the expiration (mm/yy):");
                expiration = Console.ReadLine();
                Console.WriteLine("Enter the CVV");
                cvv = Console.ReadLine();
                
                Regex regex = new Regex(pattern);
                if (Regex.IsMatch(cardNum, pattern)&& Regex.IsMatch(expiration,datePattern) && Regex.IsMatch(cvv,cvvPattern))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Card accepted!");
                    Console.ResetColor();
                    
                    IsValid = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid Card Number:");
                    Console.ResetColor();
                    IsValid = true;
                }
            }
            Console.Clear();
            DisplayReceipt(tip);
            string last = cardNum.Substring(cardNum.Length - 4);
            Console.WriteLine($"Card: ************{last}");
            runProgram = false;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Input");
            Console.ResetColor();

            runProgram = true;

        }

    }

    
}

static (double grandTotal,double tip) GetTotal()
{
    double total = 0;
    double tax = 0.06;
    double grandTotal = 0;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("DAD's Coffee Roasters Cafe");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("================================================================");
    Console.ResetColor();
    Console.WriteLine("Name".PadRight(16) + "Quantity\t" + "Subtotal");
    foreach (Cart t in Cart.orderList)
    {
        total += t.Rate;
        Console.WriteLine($"{t.Product.Name.PadRight(16)}" + $"{t.Quantity}\t\t{t.Rate}");
    }
    Console.WriteLine($"\nSubtotal: ${total}");
    Console.WriteLine($"Sales Tax: ${Math.Round(total * tax, 2)}");
    Console.Write("Enter a tip: $");
    double tip = StaticLecture.Validator.GetPositiveInputDouble();
    grandTotal = total + (total * tax) + tip;
    Console.WriteLine($"\nTotal: ${Math.Round(grandTotal,2)}");

    return (grandTotal,tip);
}

static void DisplayCart(Coffee order)
    {
        Console.WriteLine("Enter the Quantity:");
        int quantity = StaticLecture.Validator.GetPositiveInputInt();
        double total = order.Price * quantity;
        Cart.orderList.Add(new Cart(quantity, order, total));
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("================================================================");
        Console.ResetColor();
        Console.WriteLine("Name".PadRight(16) + "Quantity\t" + "Subtotal");
        foreach (Cart o in Cart.orderList)
        {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"{o.Product.Name.PadRight(16)} {o.Quantity}\t\t${o.Rate}");
        Console.ResetColor();

        }

    }
static void DisplayReceipt(double tip)
{
    double total = 0;
    double tax = 0.06;
    double grandTotal = 0;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("DAD's Coffee Roasters Cafe");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("================================================================");
    Console.ResetColor();
    Console.WriteLine("Name".PadRight(16) + "Quantity\t" + "Subtotal");
    foreach (Cart t in Cart.orderList)
    {
        total += t.Rate;
        Console.WriteLine($"{t.Product.Name.PadRight(16)}" + $"{t.Quantity}\t{t.Rate}");
    }
    Console.WriteLine($"\nSubtotal: ${total}");
    Console.WriteLine($"Sales Tax: ${Math.Round(total * tax,2)}");
    Console.WriteLine($"Tip: ${tip}");
    grandTotal = total + (total * tax) + tip;
    Console.WriteLine($"\nTotal: ${Math.Round(grandTotal, 2)}");

    
}

static string PasswordProtect ()
{
    var pass = string.Empty;
    ConsoleKey key;
    do
    {
        var keyInfo = Console.ReadKey(intercept: true);
        key = keyInfo.Key;

        if (key == ConsoleKey.Backspace && pass.Length > 0)
        {
            Console.Write("\b \b");
            pass = pass[0..^1];
        }
        else if (!char.IsControl(keyInfo.KeyChar))
        {
            Console.Write("*");
            pass += keyInfo.KeyChar;
        }
    } while (key != ConsoleKey.Enter);

    return pass;
}


static void EmployeeLogin()
{

    bool employee = StaticLecture.Validator.GetContinue("Employee Login?", "y", "n");
    Console.Clear();
    while (employee == true)
    {
        Console.WriteLine("Please enter your Employee ID");
        string? ID = Console.ReadLine();
        int IDnum;
        int password;
        if (int.TryParse(ID, out IDnum))
        {
            Console.WriteLine("Please enter your password");
        }
        string? pass = PasswordProtect();

        if (int.TryParse(pass, out password))
        {
            if (IDnum == 001 && password == 123)
            {
                Console.WriteLine("DAD's Coffee Roasters Cafe");
                Console.WriteLine("================================");
                Console.WriteLine(String.Format("\t{0,30}\t {1,10}\t {2,15}\t", "Stock Item", "Quanity", "Cost/lb"));
                Inventory.ListInventory();
                Console.WriteLine("Hit ENTER to continue to menu.");
                Console.ReadLine();
                Console.Clear();
                employee = false;
            }
            else
            {
                Console.WriteLine("Invalid login credentials.");
            }
        }
        else
        {
            Console.WriteLine("Invalid login credentials.");
        }
    }
}