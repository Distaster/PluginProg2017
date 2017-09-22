using ClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quickcode
{
    /// <summary>
    /// Interaction logic for CommandWindow.xaml
    /// </summary>
    public partial class CommandWindow : Window
    {
        public CommandWindow()
        {
            InitializeComponent();
            ArrayList k = new ArrayList();
            Importer i = new Importer();
            foreach (Construct item in i.conds)
            {
                k.Add(item);
            }
            foreach (Construct item in i.loops)
            {
                k.Add(item);
            }
            foreach (Construct item in i.others)
            {
                k.Add(item);
            }
            konstruke.ItemsSource = k;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            s = (konstruke.SelectedItem as Construct)?.execute();
            Inserter.insert(s);
            this.Close();
        }
    }
}
