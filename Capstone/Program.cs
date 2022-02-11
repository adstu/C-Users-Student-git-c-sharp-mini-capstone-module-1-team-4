﻿using System;
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

            List<Candy> candyInventory = new List<Candy>();
            List<Drinks> drinksInventory = new List<Drinks>();
            List<Chips> chipsInventory = new List<Chips>();
            List<Gum> gumInventory = new List<Gum>();

            for (int i = 0; i < itemInformation.Count; i++)
            {
                if (itemInformation[i].Contains("Candy"))
                {
                    string[] itemArray = itemInformation[i].Split("|");
                    decimal price = decimal.Parse(itemArray[3]);
                    int stock = int.Parse(itemArray[4]);                    
                    candyInventory.Add(new Candy(itemArray[1], price, itemArray[0], itemArray[2], stock));                    
                }
                if (itemInformation[i].Contains("Gum"))
                {
                    string[] itemArray = itemInformation[i].Split("|");
                    decimal price = decimal.Parse(itemArray[3]);
                    int stock = int.Parse(itemArray[4]);
                    gumInventory.Add(new Gum(itemArray[1], price, itemArray[0], itemArray[2], stock));
                }
                if (itemInformation[i].Contains("Chips"))
                {
                    string[] itemArray = itemInformation[i].Split("|");
                    decimal price = decimal.Parse(itemArray[3]);
                    int stock = int.Parse(itemArray[4]);
                    chipsInventory.Add(new Chips(itemArray[1], price, itemArray[0], itemArray[2], stock));
                }
                if (itemInformation[i].Contains("Drink"))
                {
                    string[] itemArray = itemInformation[i].Split("|");
                    decimal price = decimal.Parse(itemArray[3]);
                    int stock = int.Parse(itemArray[4]);
                    drinksInventory.Add(new Drinks(itemArray[1], price, itemArray[0], itemArray[2], stock));
                }
            }

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
