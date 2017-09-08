//------------------------------------------------------------------------------
// <copyright file="QuickCoderControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Quickcode
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for QuickCoderControl.
    /// </summary>
    public partial class QuickCoderControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuickCoderControl"/> class.
        /// </summary>
        public QuickCoderControl()
        {
            this.InitializeComponent();
            Importer i = new Importer();
            List.ItemsSource = i.loops;
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "QuickCoder");
        }
    }
}