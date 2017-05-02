using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;

namespace Calculator
{
    public partial class MainWindow : Window
    {

        string stringX, stringY, stringZ, valueHolder, memory, operation, buttonValue, equation, negativeSignX, negativeSignY;
        decimal x, y, z;
        string[] equationMemory = new string[100];
        int calculatorIncrement = 2,
            graphIncrement = 1,
            scratchpadIncrement = 1,
            index;
        bool negativeX, negativeY;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            // For each click of a numbered button or decimal, a string named buttonValue is changed to its corresponding string value
            buttonValue = "0";
            // A function named InputValue is used to store each number to a string named valueHolder
            InputValue();
            //Later the collection of these string values (e.g. 123.45) is converted to its decimal equivalent
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

        private void XBUtton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "x";
            InputValue();
        }

        private void CarrotButton_Click(object sender, RoutedEventArgs e)
        {
            buttonValue = "^";
            InputValue();
        }


        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            // An if loop is used to determine which value (stringX or stringY) warrants the negative sign
            if (stringX == null)
            {
                // A boolean is used so the value can be multiplied by -1 (if true) when the equals button is clicked
                negativeX = true;
                // Rewrites the inputBox.Text and adds a negative sign to the displayed value
                inputBox.Text = (memory + "-" + valueHolder);
                // Used for displaying the equation within inputBox
                negativeSignX = "-";
            }
            // Same as above
            else if (stringY == null)
            {
                if (valueHolder != null)
                {
                    negativeY = true;
                    inputBox.Text = (memory + negativeSignX + stringX + " " + operation + " -" + valueHolder);
                    negativeSignY = "-";
                }
            }

        }

        // Used to close the application         
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Used to close the application
        private void FileMenu_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Used to save all text within a textbox named inputBox
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        // Used to save all text within a textbox named inputBox
        private void FileMenu_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        // Used to open a previously saved TXT file
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        // Used to open a previously saved TXT file
        private void FileMenu_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        // Adds an additional calculator tabs to the stage
        private void FileMenu_AddCalculator_Click(object sender, RoutedEventArgs e)
        {
            NewCalculator();
        }

        // Adds a scratchpad tab to the stage
        private void FileMenu_AddScratchpad_Click(object sender, RoutedEventArgs e)
        {
            NewScratchpad();
        }

        // Adds a graph tab to the stage
        private void FileMenu_AddGraph_Click(object sender, RoutedEventArgs e)
        {
            NewGraph();
        }


        // Each operator uses an if loop to check whether an operator is allowed. For instance, if the user has not specific their first value, and instead simply clicks the "+" operator, no event occurs (else)
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            // On the other hand, if stringX is null, calling an operator is allowed
            if (stringX == null)
            {
                if (valueHolder != String.Empty)
                {
                    GatherValues();
                    operation = "+";
                    inputBox.Text = (inputBox.Text + " " + operation + " ");
                    UpdateCalculatorScreen();
                }
                // Our calculator does not currently support more than two values, thereforeclicking an operator after inputting a value for stringY defaults to else
            }
        }

        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            if (stringX == null)
            {
                if (valueHolder != String.Empty)
                {
                    GatherValues();
                    operation = "-";
                    inputBox.Text = (inputBox.Text + " " + operation + " ");
                    UpdateCalculatorScreen();
                }
            }
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (stringX == null)
            {
                if (valueHolder != String.Empty)
                {
                    GatherValues();
                    operation = "*";
                    inputBox.Text = (inputBox.Text + " " + operation + " ");
                    UpdateCalculatorScreen();
                }
            }
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            if (stringX == null)
            {
                if (valueHolder != String.Empty)
                {
                    GatherValues();
                    operation = "/";
                    inputBox.Text = (inputBox.Text + " " + operation + " ");
                    UpdateCalculatorScreen();
                }
            }
        }
        // Clears all stored values, including those displayed for UI purposes
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            stringX = null;
            stringY = null;
            stringZ = inputBox.Text;
            inputBox.Text = String.Empty;
            calculatorInputBox.Text = inputBox.Text;
            Array.Clear(equationMemory, 0, equationMemory.Length);
            MemorySelection.Items.Clear();
            memory = String.Empty;
            negativeX = false;
            negativeY = false;
            negativeSignX = null;
            negativeSignY = null;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {

            if (stringX != null)
            {
                // If stringX is not null, check to ensure valueHolder contains a string for stringY
                if (valueHolder != null)
                {
                    stringY = valueHolder;

                    //Each string (stringX and stringY) are then converted to their decimal equivalent
                    x = Convert.ToDecimal(stringX);
                    y = Convert.ToDecimal(stringY);

                    // If the negativeX boolean is true, the value of decimal x is multiplied by -1
                    if (negativeX == true)
                    {
                        x = x * (-1);
                    }

                    // Same as negativeX
                    if (negativeY == true)
                    {
                        y = y * (-1);
                    }

                    // If both conditions are met, a switch is used to determine which operation should be performed on the two values
                    switch (operation)
                    {
                        // The corresponding operation is performed
                        case "+":
                            // An additional decimal(z) is introduced to hold the result of the operation
                            z = x + y;
                            // Z is rounded to 17 numbers.  This is useful to avoid issues of displaying repeating number (i.e. 1 divided by 3 equals 1.3333333...).  The entire display would be filled with 3s!
                            z = Math.Round(z, 17);
                            // Z is then converted to a string to be displayed in a textbox
                            stringZ = Convert.ToString(z);
                            // A string to hold the current and previous text with the text box (inputBox) is displayed
                            inputBox.Text = (memory + negativeSignX + stringX + " " + operation + " " + negativeSignY + stringY + " = " + stringZ + "\n");
                            memory = inputBox.Text;
                            // The resulting equation is stored in a string named equation, where it is stored to a drop-down box (MemorySelection) after this switch
                            equation = (negativeSignX + stringX + " " + operation + " " + negativeSignY + stringY + " = " + stringZ);
                            break;

                        case "-":
                            z = x - y;
                            z = Math.Round(z, 17);
                            stringZ = Convert.ToString(z);
                            inputBox.Text = (memory + negativeSignX + stringX + " " + operation + " " + negativeSignY + stringY + " = " + stringZ + "\n");
                            memory = inputBox.Text;
                            equation = (negativeSignX + stringX + " " + operation + " " + negativeSignY + stringY + " = " + stringZ);
                            break;

                        case "*":
                            z = x * y;
                            z = Math.Round(z, 17);
                            stringZ = Convert.ToString(z);
                            inputBox.Text = (memory + negativeSignX + stringX + " " + operation + " " + negativeSignY + stringY + " = " + stringZ + "\n");
                            memory = inputBox.Text;
                            equation = (negativeSignX + stringX + " " + operation + " " + negativeSignY + stringY + " = " + stringZ);
                            break;

                        case "/":
                            // In the case of division, an additional if-loop checks both values (stringX (x) and stringY (y)) to see if either equals 0. If so, the answer is automatically 0
                            if (x == 0m || y == 0m)
                            {
                                z = 0m;
                                stringZ = Convert.ToString(z);
                                inputBox.Text = (memory + negativeSignX + stringX + " " + operation + " " + negativeSignY + stringY + " = " + stringZ + "\n");
                                memory = inputBox.Text;
                                equation = (negativeSignX + stringX + " " + operation + " " + negativeSignY + stringY + " = " + stringZ);
                                break;
                            }
                            else
                            {
                                z = x / y;
                                z = Math.Round(z, 17);
                                stringZ = Convert.ToString(z);
                                inputBox.Text = (memory + negativeSignX + stringX + " " + operation + " " + negativeSignY + stringY + " = " + stringZ + "\n");
                                memory = inputBox.Text;
                                equation = (negativeSignX + stringX + " " + operation + " " + negativeSignY + stringY + " = " + stringZ);
                                break;
                            }
                    }
                }
            }
            UpdateCalculatorScreen();
            // String equation is stored to a drop-down box to be recalled later if the user chooses
            InsertEquationToMemory();
            // Finally values are cleared to perform a new operation
            stringX = null;
            stringY = null;
            stringZ = null;
            valueHolder = String.Empty;
            equation = String.Empty;
            // Negative boolean for X and Y values are reset to false for next equation
            negativeX = false;
            negativeY = false;
            negativeSignX = null;
            negativeSignY = null;
        }

        // The save function uses a save file dialog which, by default, is set to save all indices in the equationMemory drop-down box to a text file
        public void SaveFile()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // The save file dialog is set, by default, to save the user's data to a text file
            saveFileDialog.DefaultExt = "txt";
            // A TXT filter is applied for ease of use
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // The save file dialog is displayed
            saveFileDialog.ShowDialog();

            // A try-block is used to avoid exceptions thrown when a user fails to save their file. For example, if the user clicks "Cancel" rather than save, an exception is thrown.
            try
            {
                // Each index (equation) in the array named equationMemory is considered
                foreach (string item in equationMemory)
                {
                    // All indices are written to user-specified file name
                    File.WriteAllLines(saveFileDialog.FileName, equationMemory);
                }
            }
            catch
            {
            }
        }

        // An open function is introduced to open previously save files and works similar to the save file dialog mentioned above.  A try-block is also used here for the same reason as the SaveFile() function.
        private void OpenFile()
        {
            TabItem tab = new TabItem();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;

            try
            {
                StreamReader readText = new StreamReader(fileName);
                string line = readText.ReadToEnd();
                TextBox inputBox2 = new TextBox();
                tab.Header = ("Calculator" + calculatorIncrement);
                tab.Content = inputBox2;
                calculatorIncrement++;
                // A new tab is created to display the newly opened file
                TabsMenu.Items.Add(tab);
                inputBox2.Text = line;
                // The newly created tab is selected for ease of use
                tab.IsSelected = true;
            }
            catch
            {
            }
        }

        // This function is used when the equals button is clicked to store the user's current equation to a string array named equationMemory
        private void InsertEquationToMemory()
        {
            index = Array.IndexOf(equationMemory, null);
            equationMemory[index] = equation;
            // The first equation is stored at equationMemory[0] and is incremented by 1 to store additional equations each time the equals button is clicked
            MemorySelection.Items.Insert(index++, equation);
        }

        // A function named InputValue is used to capture each number when its corresponding button is clicked
        private void InputValue()
        {

            inputBox.Text = inputBox.Text + buttonValue;
            // A string named valueHolder stores each successive input by the user
            valueHolder = valueHolder + buttonValue;
            // When a tab other than the initial calculator screen is displayed, the UI calculator contains a textbox to be view by the user.  When visible, the user's corresponding action is displayed.
            UpdateCalculatorScreen();
        }

        // An additional function is used to gather the value stored in valueHolder
        private void GatherValues()
        {

            // When the user clicks an operator (+, -, *, or /) the string value contained in valueHolder is assigned to either a string named stringX (if it is null) or stringY (if stringX is NOT null)
            if (stringX == null)
            {
                stringX = valueHolder;
                valueHolder = null;
            }
            else
            {
                stringY = valueHolder;
                valueHolder = null;
            }
        }

        // The UI contains a drop-down box (MemorySelection) which allows the user to recall previously entered equations
        private void MemorySelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            equation = Convert.ToString(MemorySelection.SelectedValue);
            InsertEquationToMemory();
            // When a previously entered equation is selected, the correponding display (inputBox or calculatorInputBox) is updated--whichever is active
            inputBox.Text = inputBox.Text + MemorySelection.SelectedValue + "\n";
            UpdateCalculatorScreen();
            memory = inputBox.Text;
        }

        // The user has the option to create additional tools in the tab area of their UI
        private void TabController_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tab = new TabItem();

            // A switch is used to create and display the corresponding tool type
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

        // A function to create a new calculator tab
        private void NewCalculator()
        {
            TabItem tab = new TabItem();
            // The tab's header is named
            tab.Header = ("Calculator" + calculatorIncrement);
            // The tab's name is given
            tab.Name = ("Calculator" + calculatorIncrement);
            // An integer is incremented each time a calculator tab is created.  For each successive calculator, the tab's name is changed (e.g. Calculator2, Calculator3, Calculator4...)
            calculatorIncrement++;
            // The tab is added to the TabsMenu area
            TabsMenu.Items.Add(tab);
            // A static text box is created and displayed on the tab
            tab.Content = new TextBox();
            // For ease of use, the tab is automatically selected/opened for the user
            tab.IsSelected = true;
        }

        private void NewGraph()
        {
            TabItem tab = new TabItem();
            tab.Header = ("Graph" + graphIncrement);
            tab.Name = ("Graph" + graphIncrement);
            graphIncrement++;
            // Calls a static image of a graph
            tab.Content = Application.LoadComponent(new Uri("GraphLayout.xaml", UriKind.Relative)); ;
            TabsMenu.Items.Add(tab);
            tab.IsSelected = true;
        }

        private void NewScratchpad()
        {
            TabItem tab = new TabItem();
            tab.Header = ("Scratchpad" + scratchpadIncrement);
            tab.Name = ("Scratchpad" + scratchpadIncrement);
            scratchpadIncrement++;
            TabsMenu.Items.Add(tab);
            tab.IsSelected = true;
        }

        // When the application begins, a large display/text box (inputBox) is visible to the user.  In that box, the user can perform calculations.  However, if the user chooses another tool type, a second, smaller, display is activated to display the user's most recent equations.
        private void TabsMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CalculatorTab.IsSelected == true)
            {
                calculatorInputBox.Visibility = Visibility.Hidden;
            }
            else
            {
                calculatorInputBox.Visibility = Visibility.Visible;
                calculatorInputBox.Text = inputBox.Text;
            }
        }

        private void UpdateCalculatorScreen()
        {
            calculatorInputBox.Text = inputBox.Text;
        }
    }
}