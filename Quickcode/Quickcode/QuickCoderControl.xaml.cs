//------------------------------------------------------------------------------
// <copyright file="QuickCoderControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Quickcode
{
    using InterfaceLibary;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for QuickCoderControl.
    /// </summary>
    public partial class QuickCoderControl : UserControl
    {
        Importer i;
        /// <summary>
        /// Initializes a new instance of the <see cref="QuickCoderControl"/> class.
        /// </summary>
        public QuickCoderControl()
        {
            this.InitializeComponent();
            i = new Importer();
            List.ItemsSource = i.loops;
            List2.ItemsSource = i.conds;
            List3.ItemsSource = i.others;
            List4.ItemsSource = i.myConstructs;
            DataTransport[] data = new DataTransport[1];
            data[0] = new DataTransport();
            data[0].Text = "Füg mich ein!";
            bedingungenBedingungen.ItemsSource = data;
        }

        

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender.Equals(List))
            {

                schleifenBedingung.IsEnabled = false;
                schleifenVariable.IsEnabled = false;
                schleifenCounting.IsEnabled = false;
                schleifenValue.IsEnabled = false;
                if (((sender as ListBox).SelectedItem as ILoopInterface).getEnums().Contains(InputType.LoopCondition))
                {
                    schleifenBedingung.IsEnabled = true;
                }
                if (((sender as ListBox).SelectedItem as ILoopInterface).getEnums().Contains(InputType.LoopCounter))
                {
                    schleifenCounting.IsEnabled = true;
                }
                if (((sender as ListBox).SelectedItem as ILoopInterface).getEnums().Contains(InputType.Variable))
                {
                    schleifenVariable.IsEnabled = true;
                }
                if (((sender as ListBox).SelectedItem as ILoopInterface).getEnums().Contains(InputType.VariableValue))
                {
                    schleifenValue.IsEnabled = true;
                }
            }
            else if (sender.Equals(List2))
            {
                bedingungenBedingungen.IsEnabled = false;
                bedingungenVarName.IsEnabled = false;
                if (((sender as ListBox).SelectedItem as IConditionInterface).getEnums().Contains(InputType.Variable))
                {
                    bedingungenVarName.IsEnabled = true;
                }
                if (((sender as ListBox).SelectedItem as IConditionInterface).getEnums().Contains(InputType.Conditions))
                {
                    bedingungenBedingungen.IsEnabled = true;
                }
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((sender as Button).Equals(insertBedingungen))
                {

                    IConditionInterface i = List2.SelectedItem as IConditionInterface;
                    if (i != null)
                    {
                        i.variable = bedingungenVarName.Text;
                        
                        string[] cons = new string[bedingungenAmount.SelectedIndex + 1];
                        int count = 0;
                        foreach (DataTransport item in bedingungenBedingungen.ItemsSource)
                        {
                            cons[count] = item.Text;
                            count++;
                        }
                        i.conditions = cons;
                        Inserter.insert(i.execute());
                        
                    }
                    else
                    {
                        MessageBox.Show("Du musst eine Bedingungsart aussuchen!", "Fehler!");
                    }
                }
                else if ((sender as Button).Equals(insertSchleifen))
                {
                    ILoopInterface i = List.SelectedItem as ILoopInterface;
                    if (i != null)
                    {
                        i.variable = schleifenVariable.Text;
                        i.LoopCounter = (schleifenCounting.SelectedItem as ComboBoxItem).Content.ToString();
                        i.LoopCondition = schleifenBedingung.Text;
                        i.variableValue = Int32.Parse(schleifenValue.Text);
                        Inserter.insert(i.execute());

                    }
                    else
                    {
                        MessageBox.Show("Du musst eine Schleifenart aussuchen!", "Fehler!");
                    }
                }
                else if ((sender as Button).Equals(insertAndereKonstrukte))
                {
                    IOthersInterface i = List3.SelectedItem as IOthersInterface;
                    if (i != null)
                    {
                        i.ConstructName = andereKonstrukteName.Text;
                        i.ConstructParameter = andereKonstrukteParameter.Text;
                        i.ConstructReturnValue = andereKonstrukteRueckgabetyp.Text;
                        i.ConstructVisibilty = (andereKonstrukteVisibility.SelectedItem as ComboBoxItem).Content.ToString();
                        Inserter.insert(i.execute());

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
        private void counter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int var = ((sender as ComboBox).SelectedIndex + 1);
            DataTransport[] data = new DataTransport[var];
            for (int c = 0; c < data.Length; c++)
            {
                data[c] = new DataTransport();
                data[c].Text = "Füg mich ein!";
            }
            if (bedingungenBedingungen != null)
            {
                bedingungenBedingungen.ItemsSource = data;
            }
        }
        private void ClickOnOwnConstruct(object sender, RoutedEventArgs a)
        {
            if (sender.Equals(insertEigeneKonstrukte))
            {
                Inserter.insert((List4.SelectedItem as CustomConstruct).Construct);
            }
            else if (sender.Equals(loadEigeneKonstrukte))
            {
                i.setMyConstructDirectory();
                List4.ItemsSource = i.myConstructs;
            }
            else if (sender.Equals(saveEigeneKonstrukte))
            {
                try
                {
                    i.exportTxt(eigeneKonstrukteName.Text, Clipboard.GetText());
                }
                catch (Exception e)
                {
                    MessageBox.Show("Invalider Text in der Zwischenablage!", "Warnung!");
                }
            }

        }
    }
}