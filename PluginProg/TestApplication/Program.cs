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
        [ImportMany(typeof(Switch))]
        IEnumerable<Switch> switchi = null;
        static void Main(string[] args)
        {
            new Program().run();
        }
        private void run()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (var switchi in switchi)
            {
                String[] cases = new String[5];
                cases[0] = "'a'";
                cases[1] = "'b'";
                cases[2] = "'c'";
                cases[3] = "'d'";
                cases[4] = "'e'";
                switchi.variable = "char c";
                switchi.Cases = cases;
                switchi.execute();
            }
            Console.WriteLine("fertsch");
            Console.ReadKey();
        }
    }
}

