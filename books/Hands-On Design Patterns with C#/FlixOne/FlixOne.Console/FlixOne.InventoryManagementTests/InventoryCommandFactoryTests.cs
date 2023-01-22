using FlixOne.InventoryManagement.Commands;
using FlixOne.InventoryManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests
{
    [TestClass]
    public class InventoryCommandFactoryTests
    {
        private InventoryCommandFactory Factory { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            var expectedInterface = new Helpers.TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>(),
                new List<string>());
            var context = new InventoryContext();
            Factory = new InventoryCommandFactory(expectedInterface, context);
        }

        [TestMethod]
        public void QuitCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory.GetCommand("q"), typeof(QuitCommand));
            Assert.IsInstanceOfType(Factory.GetCommand("quit"), typeof(QuitCommand));
        }
        [TestMethod]
        public void HelpCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory.GetCommand("?"), typeof(HelpCommand));
        }
        [TestMethod]
        public void UnknownCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory.GetCommand("add"), typeof(UnknownCommand));
        }
        [TestMethod]
        public void AddInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory.GetCommand("a"), typeof(AddInventoryCommand));
            Assert.IsInstanceOfType(Factory.GetCommand("addinventory"), typeof(AddInventoryCommand));
        }

        [TestMethod]
        public void GetInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory.GetCommand("g"), typeof(GetInventoryCommand));
            Assert.IsInstanceOfType(Factory.GetCommand("getinventory"), typeof(GetInventoryCommand));
        }

        [TestMethod]
        public void UpdateQuantityCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory.GetCommand("u"), typeof(UpdateQuantityCommand));
            Assert.IsInstanceOfType(Factory.GetCommand("updatequantity"), typeof(UpdateQuantityCommand));
            Assert.IsInstanceOfType(Factory.GetCommand("UpdaTEQuantity"), typeof(UpdateQuantityCommand));
        }
    }
}
