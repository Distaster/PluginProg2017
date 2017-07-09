using Interface;
using System;
using System.ComponentModel.Composition;

namespace ClassLibrary
{
    [Export(typeof(ILoopInterface))]
    public class For :Construct, ILoopInterface
    {
        public string LoopCondition { set; get; }
        public int variableValue { get; set; }
        public string LoopCounter
        {
            get; set;
        }

        public override string Name
        {
            get
            {
                return "For";
            }
        }

        public string variable
        {
            get; set;
        }

        public override void execute()
        {
            string text = "for(int " + variable +"="+variableValue+ ";"+variable + LoopCondition +";"+variable+LoopCounter+") \n { \n \n }";
            pasteInto(text);

        }
        
    }
}
