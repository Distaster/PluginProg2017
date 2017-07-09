using System;
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
using ClassLibrary;
namespace WindowTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String varKind = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            varKind=((sender as ComboBox).SelectedItem as ComboBoxItem).Tag.ToString();
            
        }

        private void counter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Tag.ToString());
            DataTransport[] data = new DataTransport[count];
            for(int i = 0; i < count; i++)
            {
                data[i] = new DataTransport();
                data[i].Text = "bitte casewert eingeben";
            }
            if (listBox != null)
            {
                listBox.ItemsSource = data;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Switch s = new Switch();
            int c = 0;
            foreach(var item in listBox.ItemsSource)
            {
                c++;
            }
            String[] cases = new String[c];
            c = 0;
            foreach(DataTransport item in listBox.ItemsSource)
            {
                if (varKind.Equals("char")){
                    cases[c] ="'"+item.Text+"'";
                }
                else
                {
                    cases[c] = item.Text;
                }
                
                c++;
            }
            s.conditions = cases;
            s.variable = varKind+" "+varname.Text;
            s.execute();

        }

       
    }
}
