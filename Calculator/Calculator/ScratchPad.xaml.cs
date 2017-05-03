using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for ScratchPad.xaml
    /// </summary>
    public partial class ScratchPad : UserControl
    {
        Point currentPoint = new Point();

        public ScratchPad()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(ScratchArea).X;
                line.Y2 = e.GetPosition(ScratchArea).Y;

                currentPoint = e.GetPosition(ScratchArea);

                ScratchArea.Children.Add(line);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ScratchArea.Children.Clear();
        }
    }
}
