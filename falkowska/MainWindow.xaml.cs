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
        int d = 5;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
            MessageBox.Show("Lista nodow :d: " + d);
        }
        private void AddNode(object sender, RoutedEventArgs e)
        {
            Graph<City> cityGraph = new Graph<City>();
            MessageBox.Show("Dodajesz noda!");
            //cityGraph["Poznan"] = new City("Poznan", "wielkopolskie", "547tys.");
            cityGraph.AddNode(new City("Poznan", "wielkopolskie", "547tys."));
            //cityGraph.AddNode(Node<City> node)
        }
    }
}
