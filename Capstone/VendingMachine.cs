using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Capstone
{
    public class VendingMachine
    {
        private static object mainProjDir;

        public string UserInput { get; set; }
        public bool IsiItOn { get; set; }
        //public Dictionary<Item, Item> ItemLocation { get; private set; }
        public decimal AvailableBalance { get; set; } = 0.00M;
        //public Inventory Inventory { get; set; }

        public int Quarters { get; set; }

        public virtual void DisplayInventory() { }

        public virtual void AssignStock() { }

        public virtual void UpdateStock(string UserInput) { }

        public void AcceptCurrency(decimal dollarAmount)
        {

            AvailableBalance += dollarAmount;

        }
        public void DisplayBalance()
        {
            Console.WriteLine("$"+ this.AvailableBalance);
        }

        public static List<string> ImportInventory()
        {
            string filePath = $"{mainProjDir}/Capstone/VendingMachineInventory.txt";
            
            
            List<string> itemInformation = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
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

        public static List<Candy> candyInventory()
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

        public static List<Gum> gumInventory()
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

        public static List<Chips> chipsInventory()
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

        public static List<Drinks> drinksInventory()
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

        public void VendItem(string userInput)
        {
            //Subtract Item from Inventory
            //item.stock -= 1;
            //Subtract cost from Available balance
            //AvailableBalance -= item.price
            bool validInput = false;
            //Dispense Item
            List<Gum> gumList = gumInventory();
            List<Chips> chipsList = chipsInventory();
            List<Drinks> drinkList = drinksInventory();
            List<Candy> candyList = candyInventory();

            int i = 0;
            foreach (Candy item in candyList)
            {
                if (UserInput == item.Location)
                {
                    validInput = true;
                    if (AvailableBalance >= item.Price)
                    {
                        
                        if (Inventory.stockDictionary[UserInput] != 0)
                        {
                            item.AvailableProduct -= 1;
                            UpdateStock(UserInput);
                            AvailableBalance -= item.Price;
                            Console.WriteLine("Munch Munch, Yum!");
                            Audit($"{DateTime.Now}  {item.Name} {item.Location} ${AvailableBalance + item.Price} ${AvailableBalance}");
                        }                            
                        else
                        {
                            Console.WriteLine("The item you selected is sold out.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money.");
                    }
                }
                i++;
                //Inventory.CandyDisplay[i].AvailableProduct = candyList[i].AvailableProduct;
            }
            foreach (Drinks item in drinkList)
            {
                if (UserInput == item.Location)
                {
                    validInput = true;
                    if (AvailableBalance >= item.Price)
                    {
                       
                        if (Inventory.stockDictionary[UserInput] != 0)
                        {
                            UpdateStock(UserInput);
                            AvailableBalance -= item.Price;
                            Console.WriteLine("You crack open a cold one with the boys");
                            Audit($"{DateTime.Now}  {item.Name} {item.Location} ${AvailableBalance + item.Price} ${AvailableBalance}");
                        }
                        else
                        {
                            Console.WriteLine("The item you selected is sold out.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money.");
                    }
                }
                i++;
            }
            foreach (Chips item in chipsList)
            {
                if (UserInput == item.Location)
                {
                    validInput = true;
                    if (AvailableBalance >= item.Price)
                    {
                        
                        if (Inventory.stockDictionary[UserInput] != 0)
                        {
                            
                            UpdateStock(UserInput);
                            AvailableBalance -= item.Price;
                            Console.WriteLine("Crunch Crunch, Yum!");
                            Audit($"{DateTime.Now}  {item.Name} {item.Location} ${AvailableBalance + item.Price} ${AvailableBalance}");
                        }
                        else
                        {
                            Console.WriteLine("The item you selected is sold out.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money.");
                    }
                    i++;
                }
            }

            foreach (Gum item in gumList)
            {
                if (UserInput == item.Location)
                {
                    validInput = true;
                    if (AvailableBalance >= item.Price)
                    {
                        if (Inventory.stockDictionary[UserInput] != 0)
                        {                            
                            UpdateStock(UserInput);
                            AvailableBalance -= item.Price;
                            Console.WriteLine("Chew Chew, Yum!");
                            Audit($"{DateTime.Now}  {item.Name} {item.Location} ${AvailableBalance + item.Price} ${AvailableBalance}");
                        }
                        else
                        {
                            Console.WriteLine("The item you selected is sold out.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money.");
                    }
                }
                i++;
            }        
            if (!validInput)
            {
                Console.WriteLine("INVALID INPUT, STRANGER");
            }
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
                    Quarters = newChange / 25;
                    Console.WriteLine(Quarters + " quarters are available to grab.");
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

                    Quarters = newChange / 25;
                    Console.WriteLine(Quarters + " quarters are available to grab.");
                    Console.WriteLine("0 dimes are available to grab.");
                    Console.WriteLine("0 nickel available to grab.");
                }
            }
            Audit($"{DateTime.Now} GIVE CHANGE: {AvailableBalance} $0.00");
            AvailableBalance = 0.00M;
            Console.WriteLine("Please grab your change.");
        }
        public void Audit(string transaction) 

        {
            string filePath = Environment.CurrentDirectory;
            string transactionAudit = "Transaction_Audit.txt";
            string fullFile = Path.Combine(filePath, transactionAudit);
            using (StreamWriter sw = new StreamWriter (fullFile, true))
            {
                sw.WriteLine(transaction);
            }
        }









    }
}
