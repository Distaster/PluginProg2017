using InterfaceLibary;
using System.ComponentModel.Composition;

namespace ClassLibrary
{
    [Export(typeof(ILoopInterface))]
    public class For :Construct, ILoopInterface
    {
        public For() : base()
        {
            
            //enums = new System.Collections.ArrayList();
            enums.Add(InputType.LoopCondition);
            enums.Add(InputType.VariableValue);
            enums.Add(InputType.LoopCounter);
            enums.Add(InputType.Variable);
            LoopCondition = "Schleifenbedingung";
            LoopCounter = "++";
            variable = "variabale";
            variableValue = 0;
        }
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

        public override string execute()
        {
            string text = "for(int " + variable +"="+variableValue+ ";"+variable + LoopCondition +";"+variable+LoopCounter+") \n { \n \n }";
            return text;

        }
        
    }
}
