using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Inventory : VendingMachine
    {
        private List<Candy> candyDisplay = candyInventory();
        private List<Chips> chipsDisplay = chipsInventory();
        private List<Gum> gumDisplay = gumInventory();
        private List<Drinks> drinksDisplay = drinksInventory();

        public List<Candy> CandyDisplay
        {
            get
            {
                return candyDisplay;
            }
            set
            {
            }
        }
        public List<Chips> ChipsDisplay
        {
            get
            {
                return chipsDisplay;
            }
            set
            {
            }
        }
        public List<Gum> GumDisplay
        {
            get
            {
                return gumDisplay;
            }
            set
            {                
            }
        }
        public List<Drinks> DrinksDisplay
        {
            get
            {
                return drinksDisplay;
            }
            set
            {               

            }
        }

        
        public static Dictionary<string, int> stockDictionary = new Dictionary<string, int>() { };

        public void AssignStock()
        {
            Dictionary<string, int> itemStock = new Dictionary<string, int>();
            List<string> itemInformation = ImportInventory();
            int i = 0;
            foreach (string item in itemInformation)
            {
                string[] itemArray = itemInformation[i].Split("|");
                itemStock[itemArray[0]] = 5;
                stockDictionary[itemArray[0]] = 5;
                i++;
            }
        }

        public void UpdateStock(string UserInput)
        {
            Inventory.stockDictionary[UserInput] -= 1;
        }

        public override void DisplayInventory()
        {

            foreach (Item item in GumDisplay)
            {
                Console.Write($"{item.Location} {item.Name} {item.Price} ");
                int result;
                if (stockDictionary.TryGetValue(item.Location, out result))
                {
                    if (result != 0)
                    {
                        Console.Write(result);
                    }
                    else
                    {
                        Console.Write("SOLD OUT");
                    }
                    Console.WriteLine("");
                }

            }
            foreach (Item item in CandyDisplay)
            {
                Console.Write($"{item.Location} {item.Name} {item.Price} ");
                int result;
                if (stockDictionary.TryGetValue(item.Location, out result))
                {
                    if (result != 0)
                    {
                        Console.Write(result);
                    }
                    else
                    {
                        Console.Write("SOLD OUT");
                    }
                    Console.WriteLine("");
                }
            }
            foreach (Item item in ChipsDisplay)
            {
                Console.Write($"{item.Location} {item.Name} {item.Price} ");
                int result;
                if (stockDictionary.TryGetValue(item.Location, out result))
                {
                    if (result != 0)
                    {
                        Console.Write(result);
                    }
                    else
                    {
                        Console.Write("SOLD OUT");
                    }
                    Console.WriteLine("");
                }
            }
            foreach (Item item in DrinksDisplay)
            {
                Console.Write($"{item.Location} {item.Name} {item.Price} ");
                int result;
                if (stockDictionary.TryGetValue(item.Location, out result))
                {
                    if (result != 0)
                    {
                        Console.Write(result);
                    }
                    else
                    {
                        Console.Write("SOLD OUT");
                    }
                    Console.WriteLine("");
                }
            }

        }

    }
}
