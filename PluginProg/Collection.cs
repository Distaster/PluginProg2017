using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginProg
{
    class Collection
    {
        [ImportMany(typeof(ConditionInterface))]
        private IEnumerable<ConditionInterface> conditions;

        [ImportMany(typeof(LoopInterface))]
        private IEnumerable<LoopInterface> loops;

        public Collection()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            container.ComposeParts();
        }

        public IEnumerable<ConditionInterface> getConditions()
        {
            return conditions;
        }

        public IEnumerable<LoopInterface> getLoops()
        {
            return loops;
        }
    }
}
