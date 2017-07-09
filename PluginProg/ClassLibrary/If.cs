using Interface;

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Export(typeof(IConditionInterface))]
    public class If :Construct, IConditionInterface
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
                return "If-Bedingung";
            }
        }

        public override void execute()
        {
            string text = "if(" + variable +" "+conditions[0]+ ") \n { \n \n }" ;
            for(int counter = 1; counter < conditions.Length; counter++)
            {
              
                   
               
                    text += "else if("+variable+" "+conditions[counter] + ")\n { \n \n }";
                
                
            }
            text += "else \n { \n \n }";
            pasteInto(text);
        }
    }
}
