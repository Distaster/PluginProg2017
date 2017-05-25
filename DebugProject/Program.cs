using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DebugProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Switch s = new Switch();
            s.pasteInto();
            RunAsSTAThread(() =>
            {
                Console.WriteLine(Clipboard.GetText());
            });
            Console.ReadKey();
        }
        static void RunAsSTAThread(Action goForIt)
        {
            AutoResetEvent @event = new AutoResetEvent(false);
            Thread thread = new Thread(
                () =>
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
