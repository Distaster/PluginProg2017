using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibary
{
    public interface IConstructInterface
    {
        string Name { get; }
        void pasteInto(String text);
        void RunAsSTAThread(Action goForIt);
        void execute();
    }
}
