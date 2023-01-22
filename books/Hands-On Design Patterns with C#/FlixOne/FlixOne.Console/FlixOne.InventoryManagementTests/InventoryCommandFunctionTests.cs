using FlixOne.InventoryManagement.Commands;
using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagement.UserInterface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests
{
    [TestClass]
    public class InventoryCommandFunctionTests
    {
        public ServiceProvider Services { get; private set; }
        public Func<string, InventoryCommand> Factory { get; private set; }

        [TestInitialize]
        public  void Startup()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddSingleton<IInventoryContext, InventoryContext>();
            services.AddTransient<Func<string, InventoryCommand>>(InventoryCommand.GetInventoryCommand);
            Services = services.BuildServiceProvider();
            Factory = Services.GetRequiredService<Func<string, InventoryCommand>>();
        }
        [TestMethod]
        public void QuitCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory("q"), typeof(QuitCommand));
            Assert.IsInstanceOfType(Factory("quit"), typeof(QuitCommand));
        }
        [TestMethod]
        public void HelpCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory("?"), typeof(HelpCommand));
        }
        [TestMethod]
        public void UnknownCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory("add"), typeof(UnknownCommand));
        }
        [TestMethod]
        public void AddInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory("a"), typeof(AddInventoryCommand));
            Assert.IsInstanceOfType(Factory("addinventory"), typeof(AddInventoryCommand));
        }

        [TestMethod]
        public void GetInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory("g"), typeof(GetInventoryCommand));
            Assert.IsInstanceOfType(Factory("getinventory"), typeof(GetInventoryCommand));
        }

        [TestMethod]
        public void UpdateQuantityCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory("u"), typeof(UpdateQuantityCommand));
            Assert.IsInstanceOfType(Factory("updatequantity"), typeof(UpdateQuantityCommand));
            Assert.IsInstanceOfType(Factory("UpdaTEQuantity"), typeof(UpdateQuantityCommand));
        }

    }
}
