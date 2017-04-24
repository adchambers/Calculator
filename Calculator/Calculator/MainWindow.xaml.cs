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

namespace Calculator
{
    public partial class MainWindow : Window
    {

        string value1, value2, value3, valueHolder, memory, operation, buttonValue, equation;
        decimal x, y, z;
        string[] equationMemory = new string[100];


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
                    InputBox.Text = (memory + value1 + " " + operation + " " + value2 + " = " + value3 + "\n\n");
                    memory = InputBox.Text;
                    equation = (value1 + " " + operation + " " + value2 + " = " + value3);
                    break;

                case "-":
                    z = x - y;
                    z = Math.Round(z, 17);
                    value3 = Convert.ToString(z);
                    InputBox.Text = (memory + value1 + " " + operation + " " + value2 + " = " + value3 + "\n\n");
                    memory = InputBox.Text;
                    equation = (value1 + " " + operation + " " + value2 + " = " + value3);
                    break;

                case "*":
                    z = x * y;
                    z = Math.Round(z, 17);
                    value3 = Convert.ToString(z);
                    InputBox.Text = (memory + value1 + " " + operation + " " + value2 + " = " + value3 + "\n\n");
                    memory = InputBox.Text;
                    equation = (value1 + " " + operation + " " + value2 + " = " + value3);
                    break;

                case "/":
                    if (x == 0m || y == 0m)
                    {
                        z = 0m;
                        value3 = Convert.ToString(z);
                        InputBox.Text = (memory + value1 + " " + operation + " " + value2 + " = " + value3 + "\n\n");
                        memory = InputBox.Text;
                        equation = (value1 + " " + operation + " " + value2 + " = " + value3);
                        break;
                    }
                    else
                    {
                        z = x / y;
                        z = Math.Round(z, 17);
                        value3 = Convert.ToString(z);
                        InputBox.Text = (memory + value1 + " " + operation + " " + value2 + " = " + value3 + "\n\n");
                        memory = InputBox.Text;
                        equation = (value1 + " " + operation + " " + value2 + " = " + value3);
                        break;
                    }
                default:
                    // Left blank intentionally
                    break;
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
            value3 = InputBox.Text;
            InputBox.Text = "0";
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
            InputBox.Text = (InputBox.Text + " " + operation + " ");
        }

        private void DifferenceButton_Click(object sender, RoutedEventArgs e)
        {
            {
                GatherValues();
                operation = "-";
                InputBox.Text = (InputBox.Text + " " + operation + " ");
            }
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            {
                GatherValues();
                operation = "*";
                InputBox.Text = (InputBox.Text + " " + operation + " ");
            }
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            {
                GatherValues();
                operation = "/";
                InputBox.Text = (InputBox.Text + " " + operation + " ");
            }
        }

        void InputValue()
        {
            InputBox.Text = InputBox.Text + buttonValue;
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

        private void MemorySelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MemorySelection.Text != "Equation History")
            {
                InputBox.Text = (InputBox.Text + MemorySelection.Text + "\n");
            }

        }
    }
}