using InterfaceLibary;
using System.ComponentModel.Composition;

namespace ClassLibrary
{
    [Export(typeof(IConditionInterface))]
    public class If :Construct, IConditionInterface
    {
        public If()
        {
            enums = new System.Collections.ArrayList();
            enums.Add(InputType.Variable);
            enums.Add(InputType.Conditions);
            variable = "variable";
            conditions = new string[1];
            conditions[0] = "Bedingung";
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
                return "If";
            }
        }

        public override string execute()
        {
            string text = "if(" + variable +" "+conditions[0]+ ") \n { \n \n }" ;
            for(int counter = 1; counter < conditions.Length; counter++)
            {
              
                   
               
                    text += "else if("+variable+" "+conditions[counter] + ")\n { \n \n }";
                
                
            }
            text += "else \n { \n \n }";
            return text;
        }
    }
}
