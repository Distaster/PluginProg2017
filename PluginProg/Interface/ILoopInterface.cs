using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ILoopInterface:IConstructInterface
    {
        string Name { get; }
        void setClipText(String text);
        
    }
}
