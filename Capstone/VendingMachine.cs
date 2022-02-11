using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        public string UserInput { get; set; }
        public bool IsiItOn { get; set; }
        public Dictionary<string, string> ItemLocation { get; private set; }
        public decimal AvailableBalance { get; private set; } = 0.00M;
        // display inventory // it will be a derived property.
        //public Dictionary<IPurchasable, int>
        

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
