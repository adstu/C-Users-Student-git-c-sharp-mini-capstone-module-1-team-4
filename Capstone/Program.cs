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
            VendingMachine vendoMatic800 = new Inventory();
            Inventory vendoMatic800Inventory = new Inventory();
            vendoMatic800Inventory.AssignStock();
            EasterEggs goodLuck = new EasterEggs();
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
                    Console.Clear();
                    
                    EasterEggs.Logo();
                    Console.WriteLine("Welcome to the Umbrella Corp. Vendo-Matic800!");
                    Console.WriteLine("What are ya buyin??");
                    
                    Console.ReadLine();

                    Console.Clear();
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
                        Console.ReadLine();
                        MainDisplay();

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
                        vendoMatic800.Ending = true;
                        Ending();
                    }
                    else
                    {
                        Console.Write("Invalid Input \n");
                        Console.ReadLine();
                    }

                 
                }
                Ending();
            }
            
             void Ending() {
                
                if (vendoMatic800.Ending)
                {


                    if (EasterEggs.EasterEgg1)
                    {
                        if (EasterEggs.EasterEgg2)
                        {
                            if (EasterEggs.EasterEgg3 && EasterEggs.Boomstick)
                            {
                                EasterEggs.GoodEndingText();
                                Console.ReadLine();
                            }
                            else
                            {
                                EasterEggs.BadEndingText();
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            EasterEggs.BadEndingText();
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        EasterEggs.BadEndingText();
                        Console.ReadLine();
                    }
                }



                System.Environment.Exit(0);

            } }
    }
}
