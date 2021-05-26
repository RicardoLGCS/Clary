using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clary
{
    abstract class ClaryConsoleCommands : ClaryConsole
    {
        protected string sKey;
        string Key
        {
            get
            {
                return sKey;
            }
        }

        protected abstract void ExecuteClaryConsoleCommand();
    }
}
