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
        [ImportMany(typeof(ILoop))]
        public ArrayList loops = null;

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
                
            }
        }
    }
}
