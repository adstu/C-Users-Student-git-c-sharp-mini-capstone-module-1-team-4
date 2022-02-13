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

        [TestMethod]
        public void ReturnChange_edgeCase()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            vendingMachine.AvailableBalance = 1000.00M;
            decimal result = 0.00M;

            //Act
            vendingMachine.ReturnChange();

            //Assert
            Assert.AreEqual(vendingMachine.AvailableBalance, result);

        }

        [TestMethod]
        public void ReturnChange_negative()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            vendingMachine.AvailableBalance = -1.00M;
            decimal result = 0.00M;

            //Act
            vendingMachine.ReturnChange();

            //Assert
            Assert.AreEqual(vendingMachine.AvailableBalance, result);

        }

        [TestMethod]
        public void ReturnChange_changeQuarters()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            vendingMachine.AvailableBalance = 1.00M;          

            //Act
            vendingMachine.ReturnChange();

            //Assert
            Assert.AreEqual(vendingMachine.Quarters, 4 );
        }

        [TestMethod]
        public void ReturnChange_changeDimes()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            vendingMachine.AvailableBalance = .45M;

            //Act
            vendingMachine.ReturnChange();

            //Assert
            Assert.AreEqual(vendingMachine.Dimes, 2);
        }

        [TestMethod]
        public void ReturnChange_changeNickel()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            vendingMachine.AvailableBalance = .40M;

            //Act
            vendingMachine.ReturnChange();

            //Assert
            Assert.AreEqual(vendingMachine.Quarters, 1);
            Assert.AreEqual(vendingMachine.Dimes, 1);
            Assert.AreEqual(vendingMachine.Nickel, 1);
        }

        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void VendingItem_Gum()
        {

            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();

            vendingMachine.UserInput = "A1";
            vendingMachine.AvailableBalance = 1.15M;
            vendingMachine.IsiItOn = true;

            //Act
            inventory.AssignStock();
            vendingMachine.VendItem(vendingMachine.UserInput);

            //Assert
            
            Assert.AreEqual(.15M, vendingMachine.AvailableBalance);
        }

        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void VendingItem_Candy()
        {

            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();

            vendingMachine.UserInput = "B1";
            vendingMachine.AvailableBalance = 2.00M;
            vendingMachine.IsiItOn = true;

            //Act
            inventory.AssignStock();
            vendingMachine.VendItem(vendingMachine.UserInput);

            //Assert

            Assert.AreEqual(.75M, vendingMachine.AvailableBalance);
        }



        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void VendingItem_Chips()
        {

            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();

            vendingMachine.UserInput = "C1";
            vendingMachine.AvailableBalance = 2.00M;
            vendingMachine.IsiItOn = true;

            //Act
            inventory.AssignStock();
            vendingMachine.VendItem(vendingMachine.UserInput);

            //Assert

            Assert.AreEqual(.50M, vendingMachine.AvailableBalance);
        }



        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void VendingItem_Drinks()
        {

            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();

            vendingMachine.UserInput = "D1";
            vendingMachine.AvailableBalance = 6.00M;
            vendingMachine.IsiItOn = true;

            //Act
            inventory.AssignStock();
            vendingMachine.VendItem(vendingMachine.UserInput);

            //Assert

            Assert.AreEqual(1.00M, vendingMachine.AvailableBalance);
        }

        //[TestMethod]
        //public void VendingItem_wrongCode()
        //{
        //    //Arrange
        //    VendingMachine vendingMachine = new VendingMachine() { };
        //    vendingMachine.UserInput = "F1";


        //    //Act
        //    vendingMachine.VendItem(vendingMachine.UserInput);



        //    //Assert
        //    Assert.IsTrue("INVALID INPUT, STRANGER");
        //}


    }

}
