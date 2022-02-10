using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
   public class Inventory
    {
        public Dictionary<string, decimal> ItemNamePrice(Item item)
        {
            string filePath = Environment.CurrentDirectory;
            string fileName = "VendingMachineInventory.txt";
            string fullFile = Path.Combine(filePath, fileName);
            Dictionary<string, decimal> startingInventory = new Dictionary<string, decimal>();
            try
            {
                using (StreamReader sr = new StreamReader(fullFile))
                {
                    while (!sr.EndOfStream)
                    { string line = sr.ReadLine();
                        if (line.Contains(item.Type))
                        {
                            string[] inventoryArray = line.Split('|');
                            decimal price = decimal.Parse(inventoryArray[2]);
                            startingInventory.Add(inventoryArray[1], price);
                        }
                    }
                    return startingInventory;
                }
            }
            catch (Exception)
            {

                throw new InvalidCastException("We really aren't too sure how this works?");
            }
        }
    }
}
