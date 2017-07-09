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
        public string[] conditions { get; set; }

        public override string Name
        {
            get
            {
                return "Switch-Bedingung";
            }
        }
        
        public override void execute()
        {
            string text = "switch("+variable+") \n { \n";
            for(int counter = 0; counter < conditions.Length; counter++)
            {
                text += "    case " + conditions[counter] + ": break; \n";
            }
            text += "}";
            pasteInto(text);
        }
    }
}
