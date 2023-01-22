using FlixOne.InventoryManagement.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests
{
    [TestClass]
    public class QuitCommandTests
    {
        [TestMethod]
        public void QuitCommand_Successful()
        {
            var expectedInterface = new Helpers.TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>
                {
                    "Thank you for using FlixOne Inventory Management System."
                },
                new List<string>());

            var command = new QuitCommand(expectedInterface);
            var result = command.RunCommand();
            expectedInterface.Validate();

            Assert.IsTrue(result.shouldQuit, "Quit is a terminating command.");
            Assert.IsTrue(result.wasSuccessful, "Quit did not complete successfully.");
        }
    }
}
