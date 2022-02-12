using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone;

namespace CapstoneTests
{
   [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void ReturnChange_happyPath()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            vendingMachine.AvailableBalance = 5.00M;
            decimal result = 0.00M;



            //Act
            vendingMachine.ReturnChange();


            //Assert
            Assert.AreEqual(vendingMachine.AvailableBalance, result);

        }






    }

}
