using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementClient
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadValue(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            return Console.ReadLine() ?? string.Empty;
        }

        public void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }

        public void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
    }
}
