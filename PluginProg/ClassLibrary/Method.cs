using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
namespace ClassLibrary
{
    public class Method : Construct, IOthersInterface
    {
        public override void execute()
        {
            string text = ConstructVisibilty+" "+ConstructReturnValue+" "+ConstructName+"("+ConstructParameter+") \n { \n ";
            if (!ConstructReturnValue.Equals("void"))
            {
                text += "   return " + ConstructReturnValue;
            }
            text+="\n }";
            pasteInto(text);
        }
        public override string Name
        {
            get
            {
                return "Methode";
            }
        }

        public string ConstructName
        {
            get; set;
        }

        public string ConstructVisibilty
        {
            get; set;
        }

        public string ConstructParameter
        {
            get; set;
        }

        public string ConstructReturnValue
        {
            get; set;
        }
    }
}
