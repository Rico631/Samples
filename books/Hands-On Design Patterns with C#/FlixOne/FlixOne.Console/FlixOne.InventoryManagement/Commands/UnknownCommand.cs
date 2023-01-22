using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Commands
{
    internal class UnknownCommand : NonTerminatingCommand
    {
        internal UnknownCommand(IUserInterface userInterface) : base(userInterface) { }

        protected override bool InternalCommand()
        {
            Interface.WriteWarning("Unable to determine the desire command");
            return false;
        }
    }
}