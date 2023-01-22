using FlixOne.InventoryManagement.Commands;
using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FlixOne.InventoryManagementClient
{
    internal interface ICatalogService
    {
        void Run();
    }
    internal class CatalogService : ICatalogService
    {
        private readonly IUserInterface _userInterface;
        private readonly Func<string, InventoryCommand> _commandFactory;

        //private readonly IInventoryCommandFactory _commandFactory;

        public CatalogService(IUserInterface userInterface, Func<string, InventoryCommand> commandFactory /*IInventoryCommandFactory commandFactory*/)
        {
            _userInterface = userInterface;
            _commandFactory = commandFactory;
            //_commandFactory = commandFactory;
        }

        public void Run()
        {
            Greeting();
            //var response = _commandFactory.GetCommand("?").RunCommand();
            var response = _commandFactory("?").RunCommand();

            while (!response.shouldQuit)
            {
                var input = _userInterface.ReadValue("> ").ToLower();
                //var command = _commandFactory.GetCommand(input);
                var command = _commandFactory(input);
                response = command.RunCommand();
                if (!response.wasSuccessful)
                    _userInterface.WriteMessage("Enter ? to view options.");
            }
        }

        private void Greeting()
        {
            // get version and display
            var version = Assembly.GetExecutingAssembly().GetName().Version!.ToString();

            _userInterface.WriteMessage("*********************************************************************************************");
            _userInterface.WriteMessage("*                                                                                           *");
            _userInterface.WriteMessage("*               Welcome to FlixOne Inventory Management System                              *");
            _userInterface.WriteMessage($"*                                                                                v{version}   *");
            _userInterface.WriteMessage("*********************************************************************************************");
            _userInterface.WriteMessage("");
        }
    }
}
