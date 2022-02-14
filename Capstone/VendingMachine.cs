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
        public decimal AvailableBalance { get; set; } = 0.00M;
        public Inventory Stock
        {
            get
            {
                Inventory stock = new Inventory();
                return stock;
            }
            set { }
        }
        public int Quarters { get; set; }
        public int Nickel { get; set; }
        public int Dimes { get; set; }
        private static string testTextFile;
        public virtual void DisplayInventory() { }

        public void AcceptCurrency(decimal dollarAmount)
        {

            AvailableBalance += dollarAmount;

        }
        public void DisplayBalance()
        {
            Console.WriteLine("$" + this.AvailableBalance);
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
                            Console.WriteLine(Nickel + " nickel(s) available to grab.");
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



            if (AvailableBalance != 0)
            {
                AvailableBalance = 0.00M;
                Console.WriteLine("Please grab your change.");
                if (EasterEggs.EasterEgg1 || EasterEggs.EasterEgg2 || EasterEggs.EasterEgg3)
                {
                    if (EasterEggs.OnceThroughOnly == false)
                    {
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("When leaning over to grab your change, you notice holes for 3 spaces. What looks like a Club, a Diamond, and a Heart.");
                        Console.ReadLine();
                        Console.WriteLine("You insert the keys you found into the corresponding holes.");
                        Console.ReadLine();
                        if (EasterEggs.EasterEgg1 && EasterEggs.EasterEgg2 && EasterEggs.EasterEgg3)
                        {
                            Console.Clear();
                            Console.WriteLine("Its Dangerous to go alone, take this, stranger...");
                            Console.ReadLine();
                            Console.Write("A secret compartment opens on the right side. You lean over and see a pump action shotgun in the opening. Do you take it? (y/n) ");
                            string takingBoomstick = Console.ReadLine();
                            if (takingBoomstick == "y" || takingBoomstick == "Y")
                            {
                                Console.Clear();
                                Console.WriteLine("This might come in handy, you think to yourself.");
                                Console.ReadLine();
                                EasterEggs.Boomstick = true;
                                EasterEggs.OnceThroughOnly = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("I'm sure I won't need it, you think to yourself.");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hmm it looks like you're missing one or more and when you turn the keys you do have, nothing happens.");
                            Console.ReadLine();
                        }
                    }

                }
            }

        }
        public void Audit(string transaction)

        {
            string filePath = Environment.CurrentDirectory;
            string transactionAudit = "Transaction_Audit.txt";
            string fullFile = Path.Combine(filePath, transactionAudit);
            using (StreamWriter sw = new StreamWriter(fullFile, true))
            {
                sw.WriteLine(transaction);
            }
        }


        public void FeedMoney()
        {
            Console.Clear();
            Console.WriteLine("How much money would you like to add?");
            Console.WriteLine("(1) - $1.00");
            Console.WriteLine("(2) - $2.00");
            Console.WriteLine("(3) - $5.00");
            Console.WriteLine("(4) - $10.00");
            Console.WriteLine("");
            Console.WriteLine("Your Available Balance is " + ("$" + AvailableBalance));
            UserInput = Console.ReadLine();
            decimal moneyAddDecimal = 0.00M;

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
            Console.Clear();
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

                Console.Clear();
                Console.WriteLine("********************************************************************");
                DisplayInventory();
                Console.WriteLine("********************************************************************");
                Console.WriteLine("Steps are getting closer.");
                Console.WriteLine("********************************************************************");
                Console.Write("Please select your item stranger:");
                UserInput = Console.ReadLine();
                if (!UserInput.Contains("A") && !UserInput.Contains("B") && !UserInput.Contains("C") && !UserInput.Contains("D"))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input");
                    Console.ReadLine();
                }
                else
                {
                    if (UserInput == "C2")
                    {
                        Console.Clear();
                        Console.WriteLine("The bag of chips is stuck.");
                        Console.Write("Do you hit the Vendo-Matic800? (y/n) ");
                        string hitMachine = Console.ReadLine();
                        if (hitMachine == "y" || hitMachine == "Y")
                        {
                            EasterEggs.HittingMachine = 1;

                            if (EasterEggs.HittingMachine == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("The bag of Spicy Sweet Chili Doritos fell, but something else fell with it.");
                                Console.ReadLine();
                                Console.WriteLine("You find a Diamond Shaped Key.");
                                EasterEggs.EasterEgg1 = true;
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Whoops it fell anyways!");
                            Console.ReadLine();
                        }
                    }
                    if (UserInput == "D2")
                    {
                        if (Inventory.stockDictionary["D2"] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("It looks like something else dropped with your cold one...");
                            Console.ReadLine();
                            Console.WriteLine("You find a Club Shaped Key.");
                            EasterEggs.EasterEgg2 = true;
                            Console.ReadLine();
                        }

                    }
                    Console.Clear();
                    VendItem(UserInput);
                    Console.ReadLine();
                }
                PurchaseMenu();

            }
            else if (userInput == "3")
            {
                Console.Clear();
                Console.WriteLine("Heh Heh! Thank ya stranger!");
                ReturnChange();
                Console.ReadLine();
                return;
            }
            else if ((userInput == "Inventory" || userInput == "inventory") && (EasterEggs.EasterEgg1 || EasterEggs.EasterEgg2 || EasterEggs.EasterEgg3))
            {
                Console.WriteLine("Instead of looking at the vending machine, you look at your inventory.");
                Console.ReadLine();
                Console.WriteLine("Inventory:");
                if (EasterEggs.EasterEgg1)
                {
                    Console.WriteLine("A Diamond Shaped Key");

                }
                if (EasterEggs.EasterEgg2)
                {
                    Console.WriteLine("A Club Shaped Key");

                }
                if (EasterEggs.EasterEgg3)
                {
                    Console.WriteLine("A Heart Shaped Key");

                }
                if (EasterEggs.Boomstick)
                {
                    Console.WriteLine("A pump action shotgun");

                }
                Console.ReadLine();
                PurchaseMenu();
            }
            else if (userInput == "5" && AvailableBalance >= 50.00M)
            {
                Console.Clear();
                Console.WriteLine("Invalid Inputttttttttttttttt...*bzzt*");
                Console.ReadLine();
                Console.WriteLine("The machine spazzes out for a moment and you hear something drop into the receiver.");
                Console.ReadLine();
                Console.WriteLine("You find a Heart Shaped Key.");
                EasterEggs.EasterEgg3 = true;
                Console.ReadLine();
                PurchaseMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input!");
                Console.ReadLine();
                PurchaseMenu();
            }

        }





    }
}
