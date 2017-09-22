using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickcode
{
    public static class Inserter
    {
        public static void insert(String text)
        {
            DTE2 dte = Package.GetGlobalService(typeof(SDTE)) as DTE2;
            var selection = (TextSelection)dte.ActiveDocument.Selection;
            if (selection != null)
            {
                selection.Insert(text);
                dte.ActiveDocument.Activate();
                dte.ExecuteCommand("Edit.FormatDocument");
            }

        }
    }
}
