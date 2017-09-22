using InterfaceLibary;
using System.ComponentModel.Composition;

namespace ClassLibrary
{
    [Export(typeof(ILoopInterface))]
    public class While : Construct,ILoopInterface
    {
        public While()
        {
            enums = new System.Collections.ArrayList();
            enums.Add(InputType.LoopCondition);
            enums.Add(InputType.Variable);
            variable = "variable";
            LoopCondition = "Bedingung";
        }
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

        public override string execute()
        {
            string text = "while(" + variable +" " + LoopCondition +") \n { \n \n }";
            return text;

        }
    }
}
