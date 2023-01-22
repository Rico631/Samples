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
    public class UpdateQuantityCommandTests
    {
        [TestMethod]
        public void UpdateQuantityCommand__Successful()
        {
            const string expectedBookName = "UpdateQuantityUnitTest";
            var expectedInterface = new Helpers.TestUserInterface(
                new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("Enter name:", expectedBookName),
                    new Tuple<string, string>("Enter quantity:", "6")
                },
                new List<string>(),
                new List<string>());

            var context = new TestInventoryContext(new Dictionary<string, Book>
            {
                { "Beavers", new Book { Id = 1, Name = "Beavers", Quantity = 3 } },
                { expectedBookName, new Book { Id = 2, Name = expectedBookName, Quantity = 7 } },
                { "Ducks", new Book { Id = 3, Name = "Ducks", Quantity = 12 } }
            });

            var command = new UpdateQuantityCommand(expectedInterface, context);
            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "UpdateQuantity is not a terminating command");
            Assert.IsTrue(result.wasSuccessful, "UpdateQuantity did not complete Successfully");

            Assert.AreEqual(0, context.GetAddedBooks().Length, "UpdateQuantity should not have added one new book");
            var updateBooks = context.GetUpdatedBooks();
            Assert.AreEqual(1, updateBooks.Length, "UpdateQuantity should have updated one new book");
            Assert.AreEqual(expectedBookName, updateBooks.First().Name, "UpdateQuantity did not update the correct book");
            Assert.AreEqual(13, updateBooks.First().Quantity, "UpdateQuantity did not update bool quantity successfully");
        }
    }
}
