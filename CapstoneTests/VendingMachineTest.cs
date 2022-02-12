﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        //[TestMethod]
        //public void ReturnChange_changeDimes()
        //{
        //    //Arrange
        //    VendingMachine vendingMachine = new VendingMachine() { };
        //    vendingMachine.AvailableBalance = 1.00M;


        //    //Act
        //    vendingMachine.ReturnChange();


        //    //Assert
        //    Assert.AreEqual(vendingMachine.Quarters, 4);
        //}

        //[TestMethod]
        //public void ReturnChange_changeNickel()
        //{
        //    //Arrange
        //    VendingMachine vendingMachine = new VendingMachine() { };
        //    vendingMachine.AvailableBalance = 1.00M;


        //    //Act
        //    vendingMachine.ReturnChange();


        //    //Assert
        //    Assert.AreEqual(vendingMachine.Quarters, 4);
        //}

        [TestMethod]
        public void VendingItem_Gum()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Gum gum = new Gum("name", 1.00M, "A1", "name", 5 );
            
            vendingMachine.UserInput = "A1";
            vendingMachine.AvailableBalance = 1.15M;
            
            //Act
            vendingMachine.VendItem(vendingMachine.UserInput);

            

            //Assert
            Assert.AreEqual(.15, vendingMachine.AvailableBalance);
        }

        //[TestMethod]
        //public void VendingItem_wrongCode()
        //{
        //    //Arrange
        //    VendingMachine vendingMachine = new VendingMachine() { };
        //    vendingMachine.UserInput = "F1";
        //    string results = 

        //    //Act
        //    vendingMachine.VendItem();



        //    //Assert
        //    Assert.IsTrue("INVALID INPUT, STRANGER");
        //}


    }

}
