using InterfaceLibary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Export(typeof(ILoop))]
    public class For : ILoop
    {
    }
}
