using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Export(typeof(LoopInterface))]
    class While : LoopInterface
    {
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
