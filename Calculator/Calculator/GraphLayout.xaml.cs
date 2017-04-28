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
    /// <summary>
    /// Interaction logic for GraphLayout.xaml
    /// </summary>
    public partial class GraphLayout : UserControl
    {
        public GraphLayout()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            function1TextBox.Clear();
            function2TextBox.Clear();
            function3TextBox.Clear();

            BitmapImage blankGraph = new BitmapImage(new Uri("/img/blankgraph.jpg", UriKind.Relative));
            GraphImage.Source = blankGraph;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (function1TextBox.Text == "x^2")
            {
                BitmapImage parabolaGraph = new BitmapImage(new Uri("/img/parabolagraph.jpg", UriKind.Relative));
                GraphImage.Source = parabolaGraph;
            }
        }
    }
}