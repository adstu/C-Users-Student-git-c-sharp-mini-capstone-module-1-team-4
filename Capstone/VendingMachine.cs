using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Capstone
{
    public class VendingMachine
    {
        
        public Inventory Stock { get {
                Inventory stock = new Inventory();
                    return stock; } set { } }
        public string UserInput { get; set; }
        public bool IsiItOn { get; set; }

        public decimal AvailableBalance { get; set; } = 0.00M;

        private static string testTextFile;

        public int Quarters { get; set; }
        public int Nickel { get; set; }
        public int Dimes { get; set; }
        public virtual void DisplayInventory() { }

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

            string currDir = Environment.CurrentDirectory;
            string mainProjDir = Directory.GetParent(currDir).Parent.Parent.Parent.FullName;
            mainProjDir = mainProjDir.Replace("\\", "/");
            testTextFile = $"{mainProjDir}/Capstone/VendingMachineInventory.txt";
            //Console.WriteLine(testTextFile);

            //string currentDirectory = Environment.CurrentDirectory;
            //string file = "VendingMachineInventory.txt";
            //string filePath = Path.Combine(currentDirectory, file);


            List<string> itemInformation = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(testTextFile))
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
                            Stock.UpdateStock(UserInput);
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
                            Stock.UpdateStock(UserInput);
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
                            
                            Stock.UpdateStock(UserInput);
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
                            Stock.UpdateStock(UserInput);
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
                    Console.WriteLine(Quarters + " quarter(s) are available to grab.");
                    if (toDimes % 10 != 0)
                    {
                        int toNickel = toDimes % 10;
                         Dimes = toDimes / 10;
                        Console.WriteLine(Dimes + " dime(s) are available to grab.");
                        if (toNickel != 0)
                        {
                            Nickel = 1;
                            Console.WriteLine( Nickel + " nickel available to grab.");
                        }
                        else
                        {
                            Console.WriteLine("0 nickel available to grab.");
                        }
                    }
                    else if (toDimes % 10 == 0)
                    {

                        Dimes = toDimes / 10;
                        Console.WriteLine(Dimes + " dimes are available to grab.");
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


        public void FeedMoney()
        {
             Console.WriteLine("How much money would you like to add?");
            Console.WriteLine("(1) - $1.00");
            Console.WriteLine("(2) - $2.00");
            Console.WriteLine("(3) - $5.00");
            Console.WriteLine("(4) - $10.00");
          
            UserInput = Console.ReadLine();
            decimal moneyAddDecimal = 0.00M;
            // void FeedMoreMoney() { }
            if (UserInput == "1")
            {
                moneyAddDecimal += 1;
                
            }
            if (UserInput == "2")
            {
                moneyAddDecimal += 2;

            }
            if (UserInput == "3")
            {
                moneyAddDecimal += 5;

            }
            if (UserInput == "4")
            {
                moneyAddDecimal += 10;
            }
            AddBalance(moneyAddDecimal);

            PurchaseMenu();

        }

        public void AddBalance(decimal moneyAddDecimal)
        {
            AcceptCurrency(moneyAddDecimal);
            Console.WriteLine("Your Available Balance is " + ("$" + AvailableBalance));
            Audit($"{DateTime.Now} FEED MONEY: ${moneyAddDecimal} ${AvailableBalance}");
        }

        public void PurchaseMenu()
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine($"Current Money Provided: ${AvailableBalance}");

            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                FeedMoney();
            }
            else if (userInput == "2")
            {
                //Display Inventory
                DisplayInventory();
                UserInput = Console.ReadLine();
                VendItem(UserInput);

                PurchaseMenu();
            }
            else if (userInput == "3")
            {
                Console.WriteLine("Heh Heh! Thank ya stranger!");
                ReturnChange();
                return;
            }
            else if (userInput == "4")
            {
                Console.WriteLine("THIS SHOULD WRITE A SALES REPORT");
            }
            else
            {
                Console.WriteLine("Invalid Input");
                PurchaseMenu();
            }

        }





    }
}
