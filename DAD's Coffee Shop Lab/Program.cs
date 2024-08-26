
using DAD_s_Coffee_Shop_Lab;
using System;
using System.ComponentModel;
using System.Xml.Serialization;
using StaticLecture;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Transactions;
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
double tip = 0;
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
    orderProgram = StaticLecture.Validator.GetContinue("Would you like to add another item to your order?", "yes", "no");
    Console.Clear();
    if (orderProgram == false)
    {
        Console.Clear();
        double finalTotal = GetTotal();
        ChoosePayment(finalTotal);
    }
}

static void ChoosePayment(double pay)
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
                Console.WriteLine("Invalid Input. Please enter a valid payment method.");
                continue;
            }
        }
        if (choice == "cash")
        {
            while (IsValid)
            {
                Console.WriteLine("Enter the amount:");
                cash = StaticLecture.Validator.GetPositiveInputDouble();
                balance = cash - pay;
                if (balance < 0)
                {
                    Console.WriteLine($"You still owe {Math.Abs(Math.Round(balance, 2))} Please enter the amount:");
                    double newbalance = StaticLecture.Validator.GetPositiveInputDouble();
                    double total = newbalance + cash;
                    double change = total - pay;
                    if (change >= 0)
                    {
                        Console.WriteLine($"Your Change:${Math.Round(change, 2)}");
                        IsValid = false;
                    }
                    else
                    {
                        Console.WriteLine($"You still owe {Math.Abs(Math.Round(change, 2))} Please enter the amount:");
                    }

                }
                else
                {
                    Console.WriteLine($"Your Change:${Math.Round(balance,2)}");
                    IsValid = false;
                }

            }
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
                    Console.WriteLine("Check accepted!");
                    IsValid = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid check Number:");
                    IsValid = true;
                }
            }
           
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
                    Console.WriteLine("Card accepted!");
                    
                    IsValid = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid Card Number:");
                    IsValid = true;
                }
            }
            runProgram = false;
        }
        else
        {
            Console.WriteLine("Invalid Input");
            runProgram = true;

        }

    }

    
}

static double GetTotal()
{
    double total = 0;
    double tax = 0.06;
    double grandTotal = 0;
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
    Console.WriteLine("Enter a tip:");
    double tip = StaticLecture.Validator.GetPositiveInputDouble();
    grandTotal = total + (total * tax) + tip;
    Console.WriteLine($"\nTotal: {Math.Round(grandTotal,2)}");

    return grandTotal;
}

    static void DisplayCart(Coffee order)
    {
        Console.WriteLine("Enter the Quantity:");
        int quantity = StaticLecture.Validator.GetPositiveInputInt();
        double total = order.Price * quantity;
        Cart.orderList.Add(new Cart(quantity, order, total));
        Console.WriteLine("================================");
        Console.WriteLine("Name".PadRight(16) + "Quantity\t" + "Subtotal");
        foreach (Cart o in Cart.orderList)
        {

            Console.WriteLine($"{o.Product.Name.PadRight(16)} {o.Quantity}\t\t{o.Rate}");


        }

    }
static void DisplayRecipt()
{
    double total = 0;
    double tax = 0.06;
    double grandTotal = 0;
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
    Console.WriteLine("Enter a tip:");
    double tip = StaticLecture.Validator.GetPositiveInputDouble();
    grandTotal = total + (total * tax) + tip;
    Console.WriteLine($"\nTotal: {Math.Round(grandTotal, 2)}");

    
}