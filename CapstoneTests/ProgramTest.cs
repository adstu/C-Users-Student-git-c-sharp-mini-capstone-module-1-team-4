using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void FeedingMoney_acceptCurrency()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine();
            decimal moneyAdded = 1.00M;


            //Act            
            vendingMachine.AcceptCurrency(moneyAdded);
            //Assert
            Assert.AreEqual(vendingMachine.AvailableBalance, 1);
        }

        [TestMethod]
        public void FeedingMoney_case1()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine();
            
            decimal amount = 1.00M;

            //Act            
            vendingMachine.AddBalance(amount);
               

            //Assert
            Assert.AreEqual(vendingMachine.AvailableBalance, 1);
        }




    }

    //void FeedMoney()
    //{
    //    Console.WriteLine("How much money would you like to add?");
    //    Console.WriteLine("(1) - $1.00");
    //    Console.WriteLine("(2) - $2.00");
    //    Console.WriteLine("(3) - $5.00");
    //    Console.WriteLine("(4) - $10.00");
    //    Console.WriteLine("(5) - Done Adding Money");
    //    string moneyAddedString = Console.ReadLine();
    //    decimal moneyAddDecimal = 0.00M;

    //    if (moneyAddedString == "1")
    //    {
    //        moneyAddDecimal += 1;
    //    }
    //    if (moneyAddedString == "2")
    //    {
    //        moneyAddDecimal += 2;
    //    }
    //    if (moneyAddedString == "3")
    //    {
    //        moneyAddDecimal += 5;
    //    }
    //    if (moneyAddedString == "4")
    //    {
    //        moneyAddDecimal += 10;
    //    }
    //    if (moneyAddedString == "5")
    //    {
    //        PurchaseMenu();
    //    }
    //    vendoMatic800.AcceptCurrency(moneyAddDecimal);
    //    Console.WriteLine("Your Available Balance is " + ("$" + vendoMatic800.AvailableBalance));
    //    vendoMatic800.Audit($"{DateTime.Now} FEED MONEY: ${moneyAddDecimal} ${vendoMatic800.AvailableBalance}");
    //    FeedMoney();
    //}


}
