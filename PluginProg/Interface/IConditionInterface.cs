using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    
    public interface IConditionInterface : IConstructInterface
    {
        int ConditionCount { set; get; }
        string Name { get; }
        void setClipText(String text);
        
    }
}
