using Interface;
using System;
using System.ComponentModel.Composition;

namespace ClassLibrary
{
    [Export(typeof(ILoopInterface))]
    class For :Construct, ILoopInterface
    {
        public string ReturnString { get; set; }
        public string Name
        {
            get
            {
                throw new NotImplementedException();
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
