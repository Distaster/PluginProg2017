using ClassLibrary;
using InterfaceLibary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quickcode
{
    public class Importer
    {
        [ImportMany(typeof(ILoopInterface))]
        public ArrayList loops = null;

        [ImportMany(typeof(IConditionInterface))]
        public ArrayList conds = null;

        [ImportMany(typeof(IOthersInterface))]
        public ArrayList others = null;

        public Importer()
        {
            try {
                var catalog = new DirectoryCatalog(".");
                var container = new CompositionContainer(catalog);                
                container.ComposeParts(this);
            }catch(ReflectionTypeLoadException e)
            {
                MessageBox.Show("Import fehlgeschlagen. Die Listen werden nun Manuell befüllt");
                loops = new ArrayList();
                loops.Add(new For());
                loops.Add(new While());
                loops.Add(new Foreach());

                conds = new ArrayList();
                conds.Add(new If());
                conds.Add(new Switch());

                others = new ArrayList();
                others.Add(new Method());

            }
        }
    }
}
