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
            VendingMachine vendoMatic800 = new VendingMachine();
            vendoMatic800.GenerateInventory();

           

            //Console.WriteLine(candyInventory[0].Name);
            //Console.WriteLine(candyInventory[1].Name);
            //Console.WriteLine(candyInventory[2].Name);
            //Console.WriteLine(candyInventory[3].Name);
            //Console.WriteLine(candyInventory[4].Name);

            //Console.WriteLine(chipsInventory[0].Name);
            //Console.WriteLine(chipsInventory[1].Name);
            //Console.WriteLine(chipsInventory[2].Name);
            //Console.WriteLine(chipsInventory[3].Name);
            //Console.WriteLine(chipsInventory[4].Name);

            //Console.WriteLine(drinksInventory[0].Name);
            //Console.WriteLine(drinksInventory[1].Name);
            //Console.WriteLine(drinksInventory[2].Name);
            //Console.WriteLine(drinksInventory[3].Name);
            //Console.WriteLine(drinksInventory[4].Name);

            //Console.WriteLine(gumInventory[0].Name);
            //Console.WriteLine(gumInventory[1].Name);
            //Console.WriteLine(gumInventory[2].Name);
            //Console.WriteLine(gumInventory[3].Name);
            //Console.WriteLine(gumInventory[4].Name);

            //string a1 = itemInformation[1];
            //Console.WriteLine(a1);



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
                        vendoMatic800.DisplayInventory();

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
                    FeedMoney();
                }
                else if (userInput == "2")
                {
                    //Display Inventory
                     vendoMatic800.UserInput = Console.ReadLine();
                    vendoMatic800.VendItem();
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Heh Heh! Thank ya stranger!");
                    vendoMatic800.ReturnChange();
                    MainDisplay();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    PurchaseMenu();
                }

            }
             void FeedMoney()
            {
                Console.WriteLine("How much money would you like to add?");
                Console.WriteLine("(1) - $1.00");
                Console.WriteLine("(2) - $2.00");
                Console.WriteLine("(3) - $5.00");
                Console.WriteLine("(4) - $10.00");
                Console.WriteLine("(5) - Done Adding Money");
                string moneyAddedString = Console.ReadLine();
                decimal moneyAddDecimal = 0.00M;

                if (moneyAddedString == "1")
                {
                    moneyAddDecimal += 1;
                }
                if (moneyAddedString == "2")
                {
                    moneyAddDecimal += 2;
                }
                if (moneyAddedString == "3")
                {
                    moneyAddDecimal += 5;
                }
                if (moneyAddedString == "4")
                {
                    moneyAddDecimal += 10;
                }
                if (moneyAddedString == "5")
                {
                    PurchaseMenu();
                }
                vendoMatic800.AcceptCurrency(moneyAddDecimal);
                Console.WriteLine("Your Available Balance is " + ("$"+  vendoMatic800.AvailableBalance));
                FeedMoney();
            }

        }
    }
}
