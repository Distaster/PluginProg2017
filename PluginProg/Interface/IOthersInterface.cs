using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IOthersInterface : IConstructInterface
    {
        string ConstructName { get; set; }
        string ConstructVisibilty { get; set; }
        string ConstructParameter { get; set; }
        string ConstructReturnValue { get; set; }
    }
}
