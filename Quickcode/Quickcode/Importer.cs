using InterfaceLibary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickcode
{
    public class Importer
    {
        [ImportMany(typeof(ILoop))]
        IEnumerable<ILoop> loops = null;

        public Importer()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
