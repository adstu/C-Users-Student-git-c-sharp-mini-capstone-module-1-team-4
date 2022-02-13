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
        public void UpdateStock_happyPath()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine() { };
            Inventory inventory = new Inventory();
            vendingMachine.UserInput = "A1";
            //vendingMachine.Stock = inventory;
            vendingMachine.AvailableBalance = 1.50M;
            //Act
            inventory.AssignStock();
            vendingMachine.VendItem(vendingMachine.UserInput);
            //Dictionary<string, int> stock = inventory.stockDictionary;
            int result = Inventory.stockDictionary[vendingMachine.UserInput];

            //Assert
            Assert.AreEqual(4, result );

        }
    }
}

//public override void UpdateStock(string UserInput)
//{
//    Inventory.stockDictionary[UserInput] -= 1;
//}