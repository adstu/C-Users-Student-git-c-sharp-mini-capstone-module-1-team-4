using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public  class VendingMachine
    {
        public int UserInput { get; set; }
        public bool IsiItOn { get; set; }
        public Dictionary<string, string> ItemLocation { get; private set; }
        public decimal AvailableBalance { get; private set; }
        // display inventory // it will be a derived property.
        //public Dictionary<IPurchasable, int>


        public void VendItem()
        {

        }

        public void AcceptCurrency()
        {
            //Available Balance
        }
        public void DisplayBalance()
        {
            Console.WriteLine(this.AvailableBalance);
        }
        public void ReturnChange()
        {
            Console.WriteLine("change");
        }
        public void MainDisplay()
        {
            Console.WriteLine($"this.");
        }

    }
}
