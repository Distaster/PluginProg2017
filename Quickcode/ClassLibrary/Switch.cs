using InterfaceLibary;
using System.ComponentModel.Composition;

namespace ClassLibrary
{
    [Export(typeof(IConditionInterface))]
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
                return "Switch";
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
