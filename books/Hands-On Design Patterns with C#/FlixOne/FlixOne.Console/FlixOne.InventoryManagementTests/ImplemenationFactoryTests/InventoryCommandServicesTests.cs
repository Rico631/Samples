using FlixOne.InventoryManagement.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.ImplemenationFactoryTests
{
    [TestClass]
    public class InventoryCommandServicesTests
    {
        public ServiceProvider Services { get; private set; }

        [TestInitialize]
        public void Startup()
        {
            var expectedInterface = new Helpers.TestUserInterface(
                    new List<Tuple<string, string>>(),
                    new List<string>(),
                    new List<string>()
                    );
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<InventoryCommand, QuitCommand>();
            services.AddTransient<InventoryCommand, HelpCommand>();
            services.AddTransient<InventoryCommand, AddInventoryCommand>();
            services.AddTransient<InventoryCommand, GetInventoryCommand>();
            services.AddTransient<InventoryCommand, UpdateQuantityCommand>();
            // UnknownCommand должна регистрироваться последней
            services.AddTransient<InventoryCommand, UnknownCommand>();
            Services = services.BuildServiceProvider();
        }

        public InventoryCommand GetCommand(string input)
        {
            return Services.GetServices<InventoryCommand>().First(svc => svc.IsCommandFor(input));
        }


        [TestMethod]
        public void QuitCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("q"), typeof(QuitCommand), "q should be QuitCommand");
            Assert.IsInstanceOfType(GetCommand("quit"), typeof(QuitCommand), "quit should be QuitCommand");
        }

        [TestMethod]
        public void HelpCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("?"), typeof(HelpCommand), "? should be HelpCommand");
        }

        [TestMethod]
        public void UnknownCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("add"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
            Assert.IsInstanceOfType(GetCommand("addinventry"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
            Assert.IsInstanceOfType(GetCommand("h"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
            Assert.IsInstanceOfType(GetCommand("help"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
        }

        [TestMethod]
        public void AddInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("a"), typeof(AddInventoryCommand), "a should be AddInventoryCommand");
            Assert.IsInstanceOfType(GetCommand("addinventory"), typeof(AddInventoryCommand), "addinventory should be AddInventoryCommand");
        }

        [TestMethod]
        public void GetInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("g"), typeof(GetInventoryCommand), "g should be GetInventoryCommand");
            Assert.IsInstanceOfType(GetCommand("getinventory"), typeof(GetInventoryCommand), "getinventory should be GetInventoryCommand");
        }

        [TestMethod]
        public void UpdateQuantityCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("u"), typeof(UpdateQuantityCommand), "u should be UpdateQuantityCommand");
            Assert.IsInstanceOfType(GetCommand("updatequantity"), typeof(UpdateQuantityCommand), "updatequantity should be UpdateQuantityCommand");
            Assert.IsInstanceOfType(GetCommand("UpdaTEQuantity"), typeof(UpdateQuantityCommand), "UpdaTEQuantity should be UpdateQuantityCommand");
        }
    }
}
