using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands
{
    public abstract class NonTerminatingCommand : InventoryCommand
    {
        protected NonTerminatingCommand(IUserInterface userInterface) : base(false, userInterface) { }
    }
}
