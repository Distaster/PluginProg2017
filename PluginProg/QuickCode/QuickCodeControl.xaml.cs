//------------------------------------------------------------------------------
// <copyright file="QuickCodeControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace QuickCode
{
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
    using Interface;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;

        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class QuickCodeControl : UserControl
        {
            [ImportMany(typeof(IConditionInterface))]
            IEnumerable<IConditionInterface> conditions = null;

            [ImportMany(typeof(ILoopInterface))]
            IEnumerable<ILoopInterface> loops = null;

            [ImportMany(typeof(IOthersInterface))]
            IEnumerable<IOthersInterface> others = null;
            public QuickCodeControl()
            {
                this.InitializeComponent();
                var catalog = new DirectoryCatalog(".");
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
                Condition.ItemsSource = conditions;
                DataTransport[] data = new DataTransport[1];
                data[0] = new DataTransport();
                data[0].Text = "Füg mich ein!";
                AllConditions.ItemsSource = data;
                OthersList.ItemsSource = others;
                LoopList.ItemsSource = loops;
                if (conditions.Count() == 0)
                {
                    MessageBox.Show("Es konnten keine Bedingungen gefunden werden!", "Fehler!");
                }
                else if (loops.Count() == 0)
                {
                    MessageBox.Show("Es konnten keine Schleifen gefunden werden!", "Fehler!");
                }
                else if (others.Count() == 0)
                {
                    MessageBox.Show("Es konnten keine anderen Konstrukte gefunden werden!", "Fehler!");

                }
            }

            private void counter_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                int var = ((sender as ComboBox).SelectedIndex + 1);
                DataTransport[] data = new DataTransport[var];
                for (int c = 0; c < data.Length; c++)
                {
                    data[c] = new DataTransport();
                    data[c].Text = "Füg mich ein!";
                }
                if (AllConditions != null)
                {
                    AllConditions.ItemsSource = data;
                }
            }

            private void button_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if ((sender as Button).Name.Equals("GenerateCondition"))
                    {

                        IConditionInterface i = Condition.SelectedItem as IConditionInterface;
                        if (i != null)
                        {
                            i.variable = Variable.Text;
                            string[] cons = new string[Counter.SelectedIndex + 1];
                            int count = 0;
                            foreach (DataTransport item in AllConditions.ItemsSource)
                            {
                                cons[count] = item.Text;
                                count++;
                            }
                            i.conditions = cons;
                            i.execute();
                        }
                        else
                        {
                            MessageBox.Show("Du musst eine Bedingungsart aussuchen!", "Fehler!");
                        }
                    }
                    else if ((sender as Button).Name.Equals("GenerateLoop"))
                    {
                        ILoopInterface i = LoopList.SelectedItem as ILoopInterface;
                        if (i != null)
                        {
                            i.variable = LoopVar.Text;
                            i.LoopCounter = (counting.SelectedItem as ComboBoxItem).Content.ToString();
                            i.LoopCondition = Abbruch.Text;
                            i.variableValue = Int32.Parse(LoopValue.Text);
                            i.execute();

                        }
                        else
                        {
                            MessageBox.Show("Du musst eine Schleifenart aussuchen!", "Fehler!");
                        }
                    }
                    else if ((sender as Button).Name.Equals("GenerateMethod"))
                    {
                        IOthersInterface i = OthersList.SelectedItem as IOthersInterface;
                        if (i != null)
                        {
                            i.ConstructName = name.Text;
                            i.ConstructParameter = parameter.Text;
                            i.ConstructReturnValue = @return.Text;
                            i.ConstructVisibilty = (sichtbarkeit.SelectedItem as ComboBoxItem).Content.ToString();
                            i.execute();

                        }
                        else
                        {
                            MessageBox.Show("Du musst eine Art aussuchen!", "Fehler!");
                        }
                    }
                }
                catch (FormatException exc)
                {
                    MessageBox.Show("Bitte geben sie bei der Variablenbefüllung nur zahlen ein!", "Fehler!");
                }
            }

            private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (((sender as ListBox).SelectedItem as ILoopInterface).Name.Equals("For"))
                {
                    LoopValue.IsEnabled = true;
                    counting.IsEnabled = true;
                }
                else
                {
                    LoopValue.IsEnabled = false;
                    counting.IsEnabled = false;
                }
            }
        }
    }

