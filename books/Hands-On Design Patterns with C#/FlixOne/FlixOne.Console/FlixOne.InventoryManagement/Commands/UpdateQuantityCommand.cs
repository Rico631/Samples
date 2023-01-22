using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlixOne.InventoryManagement.Commands
{
    internal class UpdateQuantityCommand : NonTerminatingCommand, IParameterisedCommand
    {
        private readonly IInventoryWriteContext _context;

        internal UpdateQuantityCommand(IUserInterface userInterface, IInventoryWriteContext context) : base(userInterface)
        {
            _context = context;
        }
        internal string InventoryName { get; private set; }
        private int _quantity;
        internal int Quantity { get => _quantity; private set => _quantity = value; }

        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(InventoryName))
                InventoryName = GetParameter("name");

            if (Quantity == 0)
                int.TryParse(GetParameter("quantity"), out _quantity);

            return !string.IsNullOrWhiteSpace(InventoryName) && Quantity != 0;
        }

        protected override bool InternalCommand()
        {
            return _context.UpdateQuantity(InventoryName, Quantity);
        }
    }
}
