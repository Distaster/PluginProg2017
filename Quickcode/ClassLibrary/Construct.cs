using System;
using InterfaceLibary;
using System.Threading;
using System.Windows.Forms;
using System.Collections;

namespace ClassLibrary
{
    public abstract class Construct : IConstructInterface
    {
        public Construct()
        {
            enums = new ArrayList();
        }
        public abstract string Name { get; }
       
        protected ArrayList enums;
        public void pasteInto(String text)
        {
            RunAsSTAThread(() =>
            {
                Clipboard.SetData(DataFormats.Text, (Object)text);
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
        public abstract string execute();

        public ArrayList getEnums()
        {
            return enums;
        }
    }
}
