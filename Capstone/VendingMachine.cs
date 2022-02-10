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
            Console.WriteLine("change");
        }
        public void MainDisplay()
        {
            Console.WriteLine($"(1) Display Vending Machine Items");
            Console.WriteLine($"(2) Purchase");
            Console.WriteLine($"(3) Exit");
            this.UserInput = Console.ReadLine();            
                if (UserInput == "1")
                {
                    //Display Vending Machine Items
                    
                }
                else if (UserInput == "2")
                {
                // Purchase Options
                PurchaseMenu();
                }
                else if (UserInput == "3")
                {
                    // Exit Application
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    MainDisplay();
                }     
            
        }
        public void PurchaseMenu()
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine($"Current Money Provided: {this.AvailableBalance}");
            
            string UserInput = Console.ReadLine();
            
            if (UserInput == "1")
            {
                Console.WriteLine("How much money would you like to add?");
                string moneyAddedString = Console.ReadLine();
                decimal moneyAddDecimal = decimal.Parse(moneyAddedString);
                AcceptCurrency(moneyAddDecimal);
            }
            else if (UserInput == "2")
            {
                //Display Inventory
                string userInputVending = Console.ReadLine();
                VendItem();
            }
            else if (UserInput == "3")
            {
                Console.WriteLine("Thank you for your bizznazz!");
                ReturnChange();
                MainDisplay();
            }
            else
            {
                Console.WriteLine("Invalid Input");
                PurchaseMenu();
            }
        }

    }
}
