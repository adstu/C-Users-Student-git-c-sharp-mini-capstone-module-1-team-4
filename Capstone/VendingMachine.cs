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
        public List<string> Display { get
            {
                GenerateInventory();
            } private set { } }
        //public Dictionary<IPurchasable, int>
        
        public void GenerateInventory()
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
            void DisplayInventory()
            {
                foreach (string item in itemInformation)
                {
                    Console.WriteLine(item);
                }
            }

        }
       

        public void VendItem()
        {
            //Dispense Item 
            Console.WriteLine("Please grab your item and enjoy!");
            //Subtract Item from Inventory
                //item.stock -= 1;
            //Subtract cost from Available balance
                //AvailableBalance -= item.price
        }

        public void AcceptCurrency(decimal dollarAmount)
        {
            
           AvailableBalance += dollarAmount;
            
        }
        public void DisplayBalance()
        {
            Console.WriteLine(this.AvailableBalance);
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
