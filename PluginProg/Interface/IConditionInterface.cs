﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    
    public interface IConditionInterface : IConstructInterface
    {
        
        string[] conditions { get; set; }
        string variable { get; set; }
    }
}
