//------------------------------------------------------------------------------
// <copyright file="QuickCoder.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Quickcode
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("8d5e0095-1376-4ac9-ab9a-fe792186a0a7")]
    public class QuickCoder : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuickCoder"/> class.
        /// </summary>
        public QuickCoder() : base(null)
        {
            this.Caption = "QuickCoder";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new QuickCoderControl();
        }
    }
}
