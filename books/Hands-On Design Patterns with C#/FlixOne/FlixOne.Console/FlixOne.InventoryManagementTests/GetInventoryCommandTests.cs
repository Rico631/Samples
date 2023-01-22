using FlixOne.InventoryManagement.Commands;
using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagementTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests
{
    [TestClass]
    public class GetInventoryCommandTests
    {
        [TestMethod]
        public void GetinventoryCommand_Successfull()
        {
            var expectedInterface = new Helpers.TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>
                {
                    "Gremlins                      \tQuantity:7",
                    "Willowsong                    \tQuantity:3",
                },
                new List<string>());

            var context = new TestInventoryContext(new Dictionary<string, Book>
            {
                { "Gremlins", new Book {Id = 1, Name = "Gremlins", Quantity= 7 } },
                { "Willowsong", new Book {Id = 1, Name = "Willowsong", Quantity= 3 } },
            });

            var command = new GetInventoryCommand(expectedInterface, context);
            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "GetInventory is not a terminating");
            Assert.AreEqual(0, context.GetAddedBooks().Length, "GetInventory should Not have added any books");
            Assert.AreEqual(0, context.GetUpdatedBooks().Length, "GetInventory should Not have updated any books");
        }
    }
}
