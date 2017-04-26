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
using System.IO;
using Microsoft.Win32;
using System.Drawing;


namespace Calculator
{
    public partial class MainWindow : Window
    {

        string value1, value2, value3, valueHolder, memory, operation, buttonValue, equation;
        decimal x, y, z;
        string[] equationMemory = new string[100];
        int calculatorIncrement = 2,
            graphIncrement = 1,
            scratchpadIncrement = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void InsertEquationMemory()
        {
            int index = Array.IndexOf(equationMemory, null);
            equationMemory[index] = (value1 + " " + operation + " " + value2 + " = " + value3);
            MemorySelection.Items.Insert(index++, equation);
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            value2 = valueHolder;

            x = Convert.ToDecimal(value1);
            y = Convert.ToDecimal(value2);

            switch (operation)
            {
                case "+":
                    z = x + y;
                    z = Math.Round(z, 17);
                    value3 = Convert.ToString(z);
                    inputBox.Text = (memory + value1 + " " + operation + " " + value2 + " = " + value3 + "\n\n");
                    memory = inputBox.Text;
                    equation = (value1 + " " + operation + " " + value2 + " = " + value3);
                    break;

                case "-":
                    z = x - y;
                    z = Math.Round(z, 17);
                    value3 = Convert.ToString(z);
                    inputBox.Text = (memory + value1 + " " + operation + " " + value2 + " = " + value3 + "\n\n");
                    memory = inputBox.Text;
                    equation = (value1 + " " + operation + " " + value2 + " = " + value3);
                    break;

                case "*":
                    z = x * y;
                    z = Math.Round(z, 17);
                    value3 = Convert.ToString(z);
                    inputBox.Text = (memory + value1 + " " + operation + " " + value2 + " = " + value3 + "\n\n");
                    memory = inputBox.Text;
                    equation = (value1 + " " + operation + " " + value2 + " = " + value3);
                    break;

                case "/":
                    if (x == 0m || y == 0m)
                    {
                        z = 0m;
                        value3 = Convert.ToString(z);
                        inputBox.Text = (memory + value1 + " " + operation + " " + value2 + " = " + value3 + "\n\n");
                        memory = inputBox.Text;
                        equation = (value1 + " " + operation + " " + value2 + " = " + value3);
                        break;
                    }
                    else
                    {
                        z = x / y;
                        z = Math.Round(z, 17);
                        value3 = Convert.ToString(z);
                        inputBox.Text = (memory + value1 + " " + operation + " " + value2 + " = " + value3 + "\n\n");
                        memory = inputBox.Text;
                        equation = (value1 + " " + operation + " " + value2 + " = " + value3);
                        break;
                    }
            }
            InsertEquationMemory();
            value1 = null;
            value2 = null;
            value3 = null;
            valueHolder = String.Empty;
            equation = String.Empty;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            value1 = null;
            value2 = null;
            value3 = inputBox.Text;
            inputBox.Text = "0";
            x = 0;
        }

        void GatherValues()
        {
            if (value1 == null)
            {
                value1 = valueHolder;
                valueHolder = null;
            }
            else
            {
                value2 = valueHolder;
                valueHolder = null;
            }
        }

        private void SumButton_Click(object sender, RoutedEventArgs e)
        {
            GatherValues();
            operation = "+";
            inputBox.Text = (inputBox.Text + " " + operation + " ");
        }

        private void DifferenceButton_Click(object sender, RoutedEventArgs e)
        {
            {
                GatherValues();
                operation = "-";
                inputBox.Text = (inputBox.Text + " " + operation + " ");
            }
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            {
                GatherValues();
                operation = "*";
                inputBox.Text = (inputBox.Text + " " + operation + " ");
            }
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            {
                GatherValues();
                operation = "/";
                inputBox.Text = (inputBox.Text + " " + operation + " ");
            }
        }

        void InputValue()
        {
            inputBox.Text = inputBox.Text + buttonValue;
            valueHolder = valueHolder + buttonValue;
        }

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "0";
            InputValue();
        }

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "1";
            InputValue();
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "2";
            InputValue();
        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "3";
            InputValue();
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "4";
            InputValue();
        }
        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "5";
            InputValue();
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "6";
            InputValue();
        }

        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "7";
            InputValue();
        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "8";
            InputValue();
        }

        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "9";
            InputValue();
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = ".";
            InputValue();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void FileMenu_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }


        private void FileMenu_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        private void FileMenu_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        private void FileMenu_AddCalculator_Click(object sender, RoutedEventArgs e)
        {
            NewCalculator();
        }

        private void FileMenu_AddScratchpad_Click(object sender, RoutedEventArgs e)
        {
            NewScratchpad();
        }

        private void FileMenu_AddGraph_Click(object sender, RoutedEventArgs e)
        {
            NewGraph();
        }

        private void MemorySelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            inputBox.Text = inputBox.Text + MemorySelection.SelectedValue + "\n\n";
        }

        private void TabController_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tab = new TabItem();

            switch (Convert.ToString(TabController.SelectedValue))
            {
                case "System.Windows.Controls.ComboBoxItem: Add Calculator":
                    NewCalculator();
                    break;

                case "System.Windows.Controls.ComboBoxItem: Add Graph":
                    NewGraph();
                    break;

                case "System.Windows.Controls.ComboBoxItem: Add Scratchpad":
                    NewScratchpad();
                    break;
            }
        }

        public void NewCalculator()
        {
            TabItem tab = new TabItem();
            tab.Header = ("Calculator" + calculatorIncrement);
            tab.Name = ("Calculator" + calculatorIncrement);
            calculatorIncrement++;
            TabsMenu.Items.Add(tab);
            tab.Content = new TextBox();
        }

        public void NewGraph()
        {
            TabItem tab = new TabItem();
            tab.Header = ("Graph" + graphIncrement);
            tab.Name = ("Graph" + graphIncrement);
            graphIncrement++;
            tab.Content = Application.LoadComponent(new Uri("GraphLayout.xaml", UriKind.Relative)); ;
            TabsMenu.Items.Add(tab);
        }

        public void NewScratchpad()
        {
            TabItem tab = new TabItem();
            tab.Header = ("Scratchpad" + scratchpadIncrement);
            tab.Name = ("Scratchpad" + scratchpadIncrement);
            scratchpadIncrement++;
            tab.Content = Application.LoadComponent(new Uri("GraphLayout.xaml", UriKind.Relative));
            TabsMenu.Items.Add(tab);
        }

        public void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.ShowDialog();
            File.WriteAllText(saveFileDialog.FileName, inputBox.Text);
        }
        
        public void OpenFile()
        {
            TabItem tab = new TabItem();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;

            if (File.Exists(fileName))
            {
                StreamReader readText = new StreamReader(fileName);
                String line = readText.ReadToEnd();
                TextBox inputBox2 = new TextBox();
                tab.Header = ("Calculator" + calculatorIncrement);
                tab.Content = inputBox2;
                calculatorIncrement++;
                TabsMenu.Items.Add(tab);
                inputBox2.Text = line;
                tab.IsSelected = true;
            }
        }
    }
}