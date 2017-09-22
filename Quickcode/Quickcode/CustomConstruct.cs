using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickcode
{
    public class CustomConstruct
    {
        public string Name
        {
            get; set;
        }
        public string Construct
        {
            get; set;
        }

        public CustomConstruct(string n,string c)
        {
            Name = n;
            Construct = c;
        }
    }
}
