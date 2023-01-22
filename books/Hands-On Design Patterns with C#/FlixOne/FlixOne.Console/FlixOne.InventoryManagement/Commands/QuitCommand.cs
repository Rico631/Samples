using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands
{
    internal class QuitCommand : InventoryCommand
    {
        internal QuitCommand(IUserInterface userInterface) : base(true, userInterface) { }

        protected override bool InternalCommand()
        {
            Interface.WriteMessage("Thank you for using FlixOne Inventory Management System.");
            return true;
        }
    }
}
