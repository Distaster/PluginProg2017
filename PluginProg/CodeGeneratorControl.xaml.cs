//------------------------------------------------------------------------------
// <copyright file="CodeGeneratorControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace PluginProg
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for CodeGeneratorControl.
    /// </summary>
    public partial class CodeGeneratorControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeGeneratorControl"/> class.
        /// </summary>
        public CodeGeneratorControl()
        {
            this.InitializeComponent();
            Collection col = new Collection();
            listi.ItemsSource = col.getLoops();
            listi2.ItemsSource = col.getConditions();
        }

        
    }
}