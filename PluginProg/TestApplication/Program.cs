using ClassLibrary;
using Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        Method i;
        static void Main(string[] args)
        {
            new Program().run();
        }
        private void run()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            i = new Method ();
            i.ConstructReturnValue = "int";
            i.ConstructName= "add";
            i.ConstructParameter = "int a";
            i.ConstructVisibilty = "public";
            i.execute();
          
            Console.WriteLine("fertsch");
            Console.ReadKey();
        }
    }
}

