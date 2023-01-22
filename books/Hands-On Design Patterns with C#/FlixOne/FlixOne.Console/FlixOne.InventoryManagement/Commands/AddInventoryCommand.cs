using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands
{
    internal class AddInventoryCommand : NonTerminatingCommand, IParameterisedCommand
    {
        private readonly IInventoryWriteContext _context;

        public string InventoryName { get; private set; }
        internal AddInventoryCommand(IUserInterface userInterface, IInventoryWriteContext context) : base(userInterface)
        {
            _context = context;
        }

        /// <summary>
        /// AddInventoryCommand requires name
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(InventoryName))
                InventoryName = GetParameter("name");
            return !string.IsNullOrWhiteSpace(InventoryName);
        }

        protected override bool InternalCommand()
        {
            return _context.AddBook(InventoryName);
        }
    }
}
