using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace CapstoneTests
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void UpdateStock_happyPathGum()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();
            vendingMachine.UserInput = "A1";
            
            vendingMachine.AvailableBalance = 1.50M;

            //Act            
            inventory.AssignStock();
            vendingMachine.VendItem(vendingMachine.UserInput);            
            int result = Inventory.stockDictionary[vendingMachine.UserInput];

            //Assert
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void UpdateStock_happyPathCandy()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();
            vendingMachine.UserInput = "B1";

            vendingMachine.AvailableBalance = 1.50M;
            //Act

            inventory.AssignStock();
            vendingMachine.VendItem(vendingMachine.UserInput);

            int result = Inventory.stockDictionary[vendingMachine.UserInput];

            //Assert
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void UpdateStock_happyPathChips()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();
            vendingMachine.UserInput = "C1";

            vendingMachine.AvailableBalance = 1.50M;
            //Act

            inventory.AssignStock();
            vendingMachine.VendItem(vendingMachine.UserInput);

            int result = Inventory.stockDictionary[vendingMachine.UserInput];

            //Assert
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void UpdateStock_happyPathDrinks()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();
            vendingMachine.UserInput = "D1";

            vendingMachine.AvailableBalance = 5.00M;
            //Act

            inventory.AssignStock();
            vendingMachine.VendItem(vendingMachine.UserInput);

            int result = Inventory.stockDictionary[vendingMachine.UserInput];

            //Assert
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void UpdateStock_updateStockGum()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();
            vendingMachine.UserInput = "A1";
           
           
            //Act
            inventory.AssignStock();
            inventory.UpdateStock(vendingMachine.UserInput);
            
            int result = Inventory.stockDictionary[vendingMachine.UserInput];

            //Assert
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void UpdateStock_updateStockCandy()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();
            vendingMachine.UserInput = "B1";


            //Act
            inventory.AssignStock();
            inventory.UpdateStock(vendingMachine.UserInput);

            int result = Inventory.stockDictionary[vendingMachine.UserInput];

            //Assert
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void UpdateStock_updateStockChips()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();
            vendingMachine.UserInput = "C1";


            //Act
            inventory.AssignStock();
            inventory.UpdateStock(vendingMachine.UserInput);

            int result = Inventory.stockDictionary[vendingMachine.UserInput];

            //Assert
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        [DeploymentItem(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1\VendingMachineInventory.txt")]
        public void UpdateStock_updateStockDrinks()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();
            vendingMachine.UserInput = "D1";


            //Act
            inventory.AssignStock();
            inventory.UpdateStock(vendingMachine.UserInput);

            int result = Inventory.stockDictionary[vendingMachine.UserInput];

            //Assert
            Assert.AreEqual(4, result);

        }
    }
}

//public override void UpdateStock(string UserInput)
//{
//    Inventory.stockDictionary[UserInput] -= 1;
//}