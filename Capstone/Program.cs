using System;
using System.IO;
using System.Collections.Generic;
namespace Capstone
{
    class Program
    {


        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Umbrella Corp. Vendo-Matic800!");
            Console.WriteLine("What are ya buyin??");
            Console.WriteLine(@"/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\");
            Console.WriteLine("");
            bool running = true;
            VendingMachine vendoMatic800 = new Inventory();
            Inventory vendoMatic800Inventory = new Inventory();
            vendoMatic800Inventory.AssignStock();
            //vendoMatic800.DisplayInventory();
            //vendoMatic800.candyInventory();
            //vendoMatic800.gumInventory();
            //vendoMatic800.drinksInventory();
            //vendoMatic800.chipsInventory();

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
                        Console.Clear();
                        Console.WriteLine("********************************************************************");
                        vendoMatic800.DisplayInventory();
                        Console.WriteLine("********************************************************************");
                        Console.WriteLine("You hear a rustling behind you, hurry up!");
                        Console.WriteLine("********************************************************************");

                    }
                    else if (userInput == "2")
                    {
                        // Purchase Options
                        vendoMatic800.PurchaseMenu();
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

            System.Environment.Exit(0);

        }
    }
}
