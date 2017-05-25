using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface ConditionInterface 
    {
        string Name { get; }
        void pasteInto();
        void RunAsSTAThread(Action goForIt);
    }
}
