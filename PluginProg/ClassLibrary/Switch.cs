using Interface;
using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace ClassLibrary
{
    [Export(typeof(Switch))]
    public class Switch :Construct, IConditionInterface
    {
        public string variable
        {
            get; set;
        }
        public string[] Cases { get; set; }
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
                return "Switch";
            }
        }
        public void setClipText(string text)
        {
            pasteInto(text);
        }
        public override void execute()
        {
            string text = "switch("+variable+") \n { \n";
            for(int counter = 0; counter < Cases.Length; counter++)
            {
                text += "    case " + Cases[counter] + ": break; \n";
            }
            text += "}";
            setClipText(text);
        }
    }
}
