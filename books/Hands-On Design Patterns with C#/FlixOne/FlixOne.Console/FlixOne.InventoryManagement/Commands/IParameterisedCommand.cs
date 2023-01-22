using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands
{
    public interface IParameterisedCommand
    {
        bool GetParameters();
    }
}
