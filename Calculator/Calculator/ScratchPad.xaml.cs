using Microsoft.Win32;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for ScratchPad.xaml
    /// </summary>
    public partial class ScratchPad : UserControl
    {
        const string DRAW_TOOL = "draw";
        const string TEXT_TOOL = "text";
        const string IMAGE_TOOL = "image";

        Point currentPoint = new Point();
        Point elementCurrentPoint = new Point();
        Color selectedColor = Colors.Black;
        string selectedTool = DRAW_TOOL;

        bool mouseDownCaptured = false;

        public ScratchPad()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                switch (selectedTool)
                {
                    case DRAW_TOOL:
                        currentPoint = e.GetPosition(ScratchArea);
                        break;
                    case TEXT_TOOL:
                        PlaceTextBox(e);
                        break;
                    case IMAGE_TOOL:
                        LoadImage(e);
                        break;
                    default:
                        break;
                }
            }
        }

        private void PlaceTextBox(MouseButtonEventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.MinWidth = 50;
            textBox.MinLines = 2;
            textBox.AcceptsReturn = true;
            textBox.AcceptsTab = true;
            textBox.SpellCheck.IsEnabled = true;
            textBox.MouseDown += CanvasObject_MouseDown;
            textBox.MouseMove += CanvasObject_MouseMove;
            textBox.MouseUp += CanvasObject_MouseUp;
            ScratchArea.Children.Add(textBox);
            Canvas.SetTop(textBox, e.GetPosition(ScratchArea).Y);
            Canvas.SetLeft(textBox, e.GetPosition(ScratchArea).X);
        }

        private void LoadImage(MouseButtonEventArgs e)
        {
            double x = e.GetPosition(ScratchArea).X;
            double y = e.GetPosition(ScratchArea).Y;

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Image image = new Image();
                BitmapImage uploadedImage = new BitmapImage(new Uri(op.FileName));
                image.Source = uploadedImage;
                image.MouseDown += CanvasObject_MouseDown;
                image.MouseMove += CanvasObject_MouseMove;
                image.MouseUp += CanvasObject_MouseUp;
                ScratchArea.Children.Add(image);
                Canvas.SetTop(image, y);
                Canvas.SetLeft(image, x);
            }

        }

        private void Canvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                switch (selectedTool)
                {
                    case DRAW_TOOL:
                        Draw(e);
                        break;
                }
                
            }
        }

        private void Draw(MouseEventArgs e)
        {
            Line line = new Line();

            line.Stroke = new SolidColorBrush(selectedColor);
            line.X1 = currentPoint.X;
            line.Y1 = currentPoint.Y;
            line.X2 = e.GetPosition(ScratchArea).X;
            line.Y2 = e.GetPosition(ScratchArea).Y;

            currentPoint = e.GetPosition(ScratchArea);

            ScratchArea.Children.Add(line);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ScratchArea.Children.Clear();
        }

        private void CanvasObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && mouseDownCaptured)
            {
                UIElement element = (UIElement) sender;
                double deltaX = elementCurrentPoint.X - e.GetPosition(ScratchArea).X;
                double deltaY = elementCurrentPoint.Y - e.GetPosition(ScratchArea).Y;
                Canvas.SetTop(element, Canvas.GetTop(element) - deltaY);
                Canvas.SetLeft(element, Canvas.GetLeft(element) - deltaX);
                elementCurrentPoint.X = Canvas.GetLeft(element);
                elementCurrentPoint.Y = Canvas.GetTop(element);

            }
        }

        private void CanvasObject_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseDownCaptured = false;
        }

        private void CanvasObject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                elementCurrentPoint.X = e.GetPosition(ScratchArea).X;
                elementCurrentPoint.Y = e.GetPosition(ScratchArea).Y;
                mouseDownCaptured = true;
            }

        }

        private void ColorBlack_Checked(object sender, RoutedEventArgs e)
        {
            selectedColor = Colors.Black;
        }

        private void ColorRed_Checked(object sender, RoutedEventArgs e)
        {
            selectedColor = Colors.Red;
        }

        private void ColorBlue_Checked(object sender, RoutedEventArgs e)
        {
            selectedColor = Colors.Blue;
        }

        private void ColorGreen_Checked(object sender, RoutedEventArgs e)
        {
            selectedColor = Colors.Green;
        }

        private void ToolDraw_Checked(object sender, RoutedEventArgs e)
        {
            selectedTool = DRAW_TOOL;
        }

        private void ToolText_Checked(object sender, RoutedEventArgs e)
        {
            selectedTool = TEXT_TOOL;
        }

        private void ToolImage_Checked(object sender, RoutedEventArgs e)
        {
            selectedTool = IMAGE_TOOL;
        }
    }
}
