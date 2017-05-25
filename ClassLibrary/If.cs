using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Export(typeof(ConditionInterface))]
    class If : ConditionInterface
    {
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void pasteInto()
        {
            throw new NotImplementedException();
        }

        public void RunAsSTAThread(Action goForIt)
        {
            throw new NotImplementedException();
        }
    }
}
