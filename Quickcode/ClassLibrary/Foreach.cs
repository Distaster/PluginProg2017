using InterfaceLibary;
using System.ComponentModel.Composition;

namespace ClassLibrary
{
    [Export(typeof(ILoopInterface))]
    public class Foreach : Construct, ILoopInterface
    {
        public string LoopCondition
        {
            get; set;
        }

        public string LoopCounter
        {
            get; set;
        }

        public override string Name
        {
            get
            {
                return "Foreach-Schleife";
            }
        }

        public string variable
        {
            get; set;
        }

        public int variableValue
        {
            get; set;
        }
        public override void execute()
        {
            string text = "foreach(var item in "+variable+") \n { \n \n } ";
            pasteInto(text);
        }
    }
}
