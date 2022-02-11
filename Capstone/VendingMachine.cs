using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        public string UserInput { get; set; }
        public bool IsiItOn { get; set; }
        public Dictionary<Item, Item> ItemLocation { get; private set; }
        public decimal AvailableBalance { get; private set; } = 0.00M;
        // display inventory // it will be a derived property.
        public string Display
        {
            get
            {
                string display = DisplayInventory();
                return display;
            }
            private set { }
        }


        //public Dictionary<IPurchasable, int>

        public void DisplayInventory()
        {
            List<string> itemInformation = ImportInventory();

            foreach (string item in itemInformation)
            {
                Console.WriteLine(item);
            }
        }
        public void AcceptCurrency(decimal dollarAmount)
        {

            AvailableBalance += dollarAmount;

        }
        public void DisplayBalance()
        {
            Console.WriteLine(this.AvailableBalance);
        }




        public List<string> ImportInventory()
        {
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

                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Retrieving file does not exist");
            }
            return itemInformation;
        }

        public List<Candy> candyInventory()
        {
            List<string> itemInformation = ImportInventory();

            List<Candy> candyInventory = new List<Candy>();


            for (int i = 0; i < itemInformation.Count; i++)
            {
                if (itemInformation[i].Contains("Candy"))
                {
                    string[] itemArray = itemInformation[i].Split("|");
                    decimal price = decimal.Parse(itemArray[3]);
                    int stock = int.Parse(itemArray[4]);
                    candyInventory.Add(new Candy(itemArray[1], price, itemArray[0], itemArray[2], stock));
                }
            }
            return candyInventory;
        }

        public List<Gum> gumInventory()
        {
            List<string> itemInformation = ImportInventory();
            List<Gum> gumInventory = new List<Gum>();
            for (int i = 0; i < itemInformation.Count; i++)
            {
                if (itemInformation[i].Contains("Gum"))
                {
                    string[] itemArray = itemInformation[i].Split("|");
                    decimal price = decimal.Parse(itemArray[3]);
                    int stock = int.Parse(itemArray[4]);
                    gumInventory.Add(new Gum(itemArray[1], price, itemArray[0], itemArray[2], stock));

                }
            }
            return gumInventory;
        }

        public List<Chips> chipsInventory()
        {
            List<string> itemInformation = ImportInventory();
            List<Chips> chipsInventory = new List<Chips>();
            for (int i = 0; i < itemInformation.Count; i++)
            {
                if (itemInformation[i].Contains("Chips"))
                {
                    string[] itemArray = itemInformation[i].Split("|");
                    decimal price = decimal.Parse(itemArray[3]);
                    int stock = int.Parse(itemArray[4]);
                    chipsInventory.Add(new Chips(itemArray[1], price, itemArray[0], itemArray[2], stock));
                }
            }
            return chipsInventory;
        }

        public List<Drinks> drinksInventory()
        {
            List<string> itemInformation = ImportInventory();
            List<Drinks> drinksInventory = new List<Drinks>();
            for (int i = 0; i < itemInformation.Count; i++)
            {
                if (itemInformation[i].Contains("Drink"))
                {
                    string[] itemArray = itemInformation[i].Split("|");
                    decimal price = decimal.Parse(itemArray[3]);
                    int stock = int.Parse(itemArray[4]);
                    drinksInventory.Add(new Drinks(itemArray[1], price, itemArray[0], itemArray[2], stock));
                }
            }
            return drinksInventory;
        }

        public void VendItem()
        {
            //Subtract Item from Inventory
            //item.stock -= 1;
            //Subtract cost from Available balance
            //AvailableBalance -= item.price

            List<Gum> gumList = gumInventory();
            List<Chips> chipsList = chipsInventory();
            List<Drinks> drinkList = drinksInventory();
            List<Candy> candyList = candyInventory();
            //Dispense Item
            foreach (Candy item in candyList)
            {
                if (UserInput == item.Location)
                {
                    if (AvailableBalance >= item.Price)
                    {
                        item.AvailableProduct -= 1;
                        AvailableBalance -= item.Price;
                        Console.WriteLine("Candy Message");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money you POS");
                    }
                }

            }
            foreach (Drinks item in drinkList)
            {
                if (UserInput == item.Location)
                {
                    if (AvailableBalance >= item.Price)
                    {
                        item.AvailableProduct -= 1;
                        AvailableBalance -= item.Price;
                        Console.WriteLine("Candy Message");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money you POS");
                    }
                }

            }
            foreach (Chips item in chipsList)
            {
                if (UserInput == item.Location)
                {
                    if (AvailableBalance >= item.Price)
                    {
                        item.AvailableProduct -= 1;
                        AvailableBalance -= item.Price;
                        Console.WriteLine("Candy Message");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money you POS");
                    }
                }

            }
            foreach (Gum item in gumList)
            {
                if (UserInput == item.Location)
                {
                    if (AvailableBalance >= item.Price)
                    {
                        item.AvailableProduct -= 1;
                        AvailableBalance -= item.Price;
                        Console.WriteLine("Candy Message");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money you POS");
                    }
                }

            }
            Console.WriteLine("Please grab your item and enjoy!");
        }

        public void ReturnChange()
        {
            if (AvailableBalance > 0)
            {
                decimal change = AvailableBalance * 100;
                int newChange = Decimal.ToInt32(change);

                if (newChange % 25 != 0)
                {
                    int toDimes = newChange % 25;
                    int quarters = newChange / 25;
                    Console.WriteLine(quarters + " quarters are available to grab.");
                    if (toDimes % 10 != 0)
                    {
                        int toNickel = toDimes % 10;
                        int dimes = toDimes / 10;
                        Console.WriteLine(dimes + " dimes are available to grab.");
                        if (toNickel != 0)
                        {
                            Console.WriteLine("1 nickel available to grab.");
                        }
                        else
                        {
                            Console.WriteLine("0 nickel available to grab.");
                        }
                    }
                    else if (newChange % 10 == 0)
                    {

                        int dimes = newChange / 10;
                        Console.WriteLine(dimes + " dimes are available to grab.");
                        Console.WriteLine("0 nickel available to grab.");
                    }
                }
                if (newChange % 25 == 0)
                {

                    int quarters = newChange / 25;
                    Console.WriteLine(quarters + " quarters are available to grab.");
                    Console.WriteLine("0 dimes are available to grab.");
                    Console.WriteLine("0 nickel available to grab.");
                }
            }
            AvailableBalance = 0.00M;
            Console.WriteLine("Please grab your change.");
        }


    }
}
