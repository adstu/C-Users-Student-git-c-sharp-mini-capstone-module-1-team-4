using System;
using System.IO;
using System.Collections.Generic;
namespace Capstone
{
    class Program
    {


        static void Main(string[] args)
        {
            bool running = true;
            VendingMachine vendoMatic800 = new VendingMachine();


            string filePath = Environment.CurrentDirectory;
            string fileName = "VendingMachineInventory.txt";
            string fullFile = Path.Combine(filePath, fileName);
            List<string> itemInformation = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(fullFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        itemInformation.Add(line);
                        Console.WriteLine($"{line}");
                    }
                    
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Retrieving file does not exist");
            }
            string a1 = itemInformation[1];
            Console.WriteLine(a1);



            MainDisplay();


            void MainDisplay()
            {
                while (running)
                {
                    Console.WriteLine($"(1) Display Vending Machine Items");
                    Console.WriteLine($"(2) Purchase");
                    Console.WriteLine($"(3) Exit");
                    string userInput = Console.ReadLine();
                    if (userInput == "1")
                    {
                        //Display Vending Machine Items

                    }
                    else if (userInput == "2")
                    {
                        // Purchase Options
                        PurchaseMenu();
                    }
                    else if (userInput == "3")
                    {
                        // Exit Application
                        running = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");

                    }
                }
                Console.WriteLine("Thank you, please come again!");
            }



            void PurchaseMenu()
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine($"Current Money Provided: {vendoMatic800.AvailableBalance}");

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("How much money would you like to add?");
                    string moneyAddedString = Console.ReadLine();
                    decimal moneyAddDecimal = decimal.Parse(moneyAddedString);
                    vendoMatic800.AcceptCurrency(moneyAddDecimal);
                }
                else if (userInput == "2")
                {
                    //Display Inventory
                    string userInputVending = Console.ReadLine();
                    vendoMatic800.VendItem();
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Thank you for your bizznazz!");
                    vendoMatic800.ReturnChange();
                    MainDisplay();

                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    PurchaseMenu();
                }


            }


        }
    }
}
