using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibary
{
    public interface ILoopInterface:IConstructInterface
    {
        
        string LoopCondition { set; get; }
        string variable { get; set; }
        string LoopCounter { get; set; }
        int variableValue { get; set; }
    }
}
