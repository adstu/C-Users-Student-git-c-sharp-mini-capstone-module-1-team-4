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




}
