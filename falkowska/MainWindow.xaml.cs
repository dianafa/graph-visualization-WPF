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
using CityGraph;
using GraphLibrary;

namespace falkowska
{
    ///trzeba przeciazyc operator castowania
    ///zamiast >> i << uzywaj .AddArc(). i zawsze z lewego do prawego bedzie
    public partial class MainWindow : Window
    {
        Graph<City> cityGraph;
        int d = 5;
        public MainWindow()
        {
            InitializeComponent();
            cityGraph = new Graph<City>();
            cityGraph["Poznan"] = new City("Poznan", "wielkopolskie", "547tys.");
        }

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
            MessageBox.Show("Lista nodow :d: " + d);
        }
        private void AddNode(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" cityGraph[Poznan].name: " + cityGraph["Poznan"].name);
            //cityGraph["Poznan"] = new City("Poznan", "wielkopolskie", "547tys.");
            cityGraph.AddNode(new City("Krakow", "wielkopolskie", "647tys."));
            //cityGraph.AddNode(Node<City> node)
        }
    }
}
