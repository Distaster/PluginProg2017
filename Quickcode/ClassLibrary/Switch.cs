using InterfaceLibary;
using System.ComponentModel.Composition;

namespace ClassLibrary
{
    [Export(typeof(IConditionInterface))]
    public class Switch :Construct, IConditionInterface
    {
        public Switch()
        {
            enums = new System.Collections.ArrayList();
            enums.Add(InputType.Variable);
            enums.Add(InputType.Conditions);
            variable = "variable";
            conditions = new string[1];
            conditions[0] = "Wert";
        }
        public string variable
        {
            get; set;
        }
        public string[] conditions { get; set; }

        public override string Name
        {
            get
            {
                return "Switch";
            }
        }
        
        public override string execute()
        {
            string text = "switch("+variable+") \n { \n";
            for(int counter = 0; counter < conditions.Length; counter++)
            {
                text += "    case " + conditions[counter] + ": break; \n";
            }
            text += "}";
            return text;
        }
    }
}
