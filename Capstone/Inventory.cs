using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Inventory : VendingMachine
    {
       
               List<Candy> CandyDisplay
               {
                   get
                   {
                      return candyInventory();
                   }
                   set { }
               }
               List<Chips> ChipsDisplay
               {
                   get
                   {
                       return chipsInventory();
                   }
                   set { }
               }
               List<Gum> GumDisplay
               {
                   get
                   {
                       return gumInventory();
                   }
                   set { }
               }
               List<Drinks> DrinksDisplay
               {
                   get
                   {
                       return drinksInventory();
                   }
                   set { }
               }

        public void DisplayInventory()
        {
            
            foreach (Item item in GumDisplay)
            {
                Console.WriteLine($"{item.Location} {item.Name} {item.Price} {item.AvailableProduct}");
            }
            foreach (Item item in CandyDisplay)
            {
                Console.WriteLine($"{item.Location} {item.Name} {item.Price} {item.AvailableProduct}");
            }
            foreach (Item item in ChipsDisplay)
            {
                Console.WriteLine($"{item.Location} {item.Name} {item.Price} {item.AvailableProduct}");
            }
            foreach (Item item in DrinksDisplay)
            {
                Console.WriteLine($"{item.Location} {item.Name} {item.Price} {item.AvailableProduct}");
            }

        }

    }
}
