//------------------------------------------------------------------------------
// <copyright file="AddAdornment.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Editor;
using CommentAdornmentTest;

namespace MenuCommandtest
{
	/// <summary>
	/// Command handler
	/// </summary>
	internal sealed class AddAdornment
	{
		/// <summary>
		/// Command ID.
		/// </summary>
		public const int CommandId = 0x0100;

		/// <summary>
		/// Command menu group (command set GUID).
		/// </summary>
		public static readonly Guid CommandSet = new Guid("1a3aefa3-9b0e-4652-a447-5454c3c48b5b");

		/// <summary>
		/// VS Package that provides this command, not null.
		/// </summary>
		private readonly Package package;

		/// <summary>
		/// Initializes a new instance of the <see cref="AddAdornment"/> class.
		/// Adds our command handlers for menu (commands must exist in the command table file)
		/// </summary>
		/// <param name="package">Owner package, not null.</param>
		private AddAdornment(Package package)
		{
			if (package == null)
			{
				throw new ArgumentNullException(nameof(package));
			}

			this.package = package;

			OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
			if (commandService != null)
			{
				CommandID menuCommandID = new CommandID(MenuGroup, CommandId);
				EventHandler eventHandler = this.AddAdornmentHandler;
				MenuCommand menuItem = new MenuCommand(eventHandler, menuCommandID);
				commandService.AddCommand(menuItem);
			}
		}

		/// <summary>
		/// Gets the instance of the command.
		/// </summary>
		public static AddAdornment Instance
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the service provider from the owner package.
		/// </summary>
		private IServiceProvider ServiceProvider
		{
			get
			{
				return this.package;
			}
		}

		public Guid MenuGroup { get; private set; }

		/// <summary>
		/// Initializes the singleton instance of the command.
		/// </summary>
		/// <param name="package">Owner package, not null.</param>
		public static void Initialize(Package package)
		{
			Instance = new AddAdornment(package);
		}

		/// <summary>
		/// This function is the callback used to execute the command when the menu item is clicked.
		/// See the constructor to see how the menu item is associated with this function using
		/// OleMenuCommandService service and MenuCommand class.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event args.</param>
		private void MenuItemCallback(object sender, EventArgs e)
		{
			string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
			string title = "AddAdornment";

			// Show a message box to prove we were here
			VsShellUtilities.ShowMessageBox(
				this.ServiceProvider,
				message,
				title,
				OLEMSGICON.OLEMSGICON_INFO,
				OLEMSGBUTTON.OLEMSGBUTTON_OK,
				OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
		}

		private void AddAdornmentHandler(object sender, EventArgs e)
		{
			IVsTextManager txtMgr = (IVsTextManager)ServiceProvider.GetService(typeof(SVsTextManager));
			IVsTextView vTextView = null;
			int mustHaveFocus = 1;
			txtMgr.GetActiveView(mustHaveFocus, null, out vTextView);
			IVsUserData userData = vTextView as IVsUserData;
			if (userData == null)
			{
				Console.WriteLine("No text view is currently open");
				return;
			}
			IWpfTextViewHost viewHost;
			object holder;
			Guid guidViewHost = DefGuidList.guidIWpfTextViewHost;
			userData.GetData(ref guidViewHost, out holder);
			viewHost = (IWpfTextViewHost)holder;
			Connector.Execute(viewHost);
		}
	}

}
