using Interface;
using System;
using System.ComponentModel.Composition;

namespace ClassLibrary
{
    [Export(typeof(ILoopInterface))]
    class While : Construct,ILoopInterface
    {
        public string ReturnString { get; set; }
        public string Name
        {
            get
            {
                return "While-Schleife";
            }
        }
        public void setClipText(string text)
        {
            pasteInto(text);
        }
        public override void execute()
        {

        }
    }
}
