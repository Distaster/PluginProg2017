using Interface;

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Export(typeof(IConditionInterface))]
    class If :Construct, IConditionInterface
    {
        public string ReturnString { get; set; }
        public int ConditionCount
        {
            get
            {
                return ConditionCount;
            }

            set
            {
                ConditionCount = value;
            }
        }

        public string Name
        {
            get
            {
                return "If-Bedingung";
            }
        }

        public override void execute()
        {
            
        }
        
        public void setClipText(string text)
        {
            pasteInto(text);
        }
    }
}
