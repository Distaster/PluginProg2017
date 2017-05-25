using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibrary
{
    [Export(typeof(ConditionInterface))]
    public class Switch : ConditionInterface
    {
        public string Name
        {
            get
            {
                return "Switch";
            }
        }

        public void pasteInto()
        {
            RunAsSTAThread(() =>
            {

                string s = "switch(var i){" + "\n";
                Console.WriteLine("Wie viele Cases?");
                int c = Console.ReadKey().KeyChar-'0';
                Console.WriteLine();
                for(int i = 0; i < c; i++)
                {
                    s += "   case "+i+":   break;" + "\n";
                }
                s += "}";
                Clipboard.SetData(DataFormats.Text, (Object)s);
            });            
        }
        public void RunAsSTAThread(Action goForIt)
        {
            AutoResetEvent @event = new AutoResetEvent(false);
            Thread thread = new Thread(() =>
                {
                    goForIt();
                    @event.Set();
                });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            @event.WaitOne();
        }
    }
}
