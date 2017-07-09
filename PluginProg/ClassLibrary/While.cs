using Interface;
using System;
using System.ComponentModel.Composition;

namespace ClassLibrary
{
    [Export(typeof(ILoopInterface))]
    public class While : Construct,ILoopInterface
    {
        public string LoopCondition { set; get; }

        public string LoopCounter
        {
            get; set;
        }
        public int variableValue { get; set; }
        public override string Name
        {
            get
            {
                return "While";
            }
        }

        public string variable
        {
            get; set;
        }

        public override void execute()
        {
            string text = "while(" + variable +" " + LoopCondition +") \n { \n \n }";
            pasteInto(text);

        }
    }
}
