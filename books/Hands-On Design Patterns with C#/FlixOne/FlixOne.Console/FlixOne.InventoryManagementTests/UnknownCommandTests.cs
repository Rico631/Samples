using FlixOne.InventoryManagement.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests
{
    [TestClass]
    public class UnknownCommandTests
    {
        [TestMethod]
        public void UnknownCommand_Successful()
        {
            var expectedInterface = new Helpers.TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>(),
                new List<string>
                {
                    "Unable to determine the desire command"
                });

            var command = new UnknownCommand(expectedInterface);
            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "UnknownCommand is not a terminating command");
            Assert.IsFalse(result.wasSuccessful, "UnknownCommand should not complete Successfully");
        }
    }
}
