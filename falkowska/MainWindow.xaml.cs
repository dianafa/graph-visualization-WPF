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
        public List<String> lista;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            cityGraph = new Graph<City>();
            cityGraph["Poznan"] = new City("Poznan", "wielkopolskie", "547tys.");
            cityGraph.AddNode(new City("Krakow", "wielkopolskie", "647tys."));
            MessageBox.Show("cityGraph.nodes[0]: " + cityGraph.nodes["Poznan"]);
            lbNodes.ItemsSource = cityGraph.nodes;
           
            lista = new List<String>();
            lista.Add("diana");
            lista.Add("pies");
            //lbNodes.ItemsSource = lista;

        }

        private void MainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
            MessageBox.Show("cityGraph.nodeCount: " + cityGraph.nodes.Count);
        }
        private void AddNode(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" cityGraph[Poznan].name: " + cityGraph["Poznan"].name);
            cityGraph["Bydgoszcz"] = new City("Bydgoszcz", "kujawsko-pomorskie", "297tys.");
            MessageBox.Show("cityGraph.nodeCount: " + cityGraph.nodes.Count);
            lbNodes.ItemsSource = null;
            lbNodes.ItemsSource = cityGraph.nodes;
        }

        private void EditNode(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edytujesz noda: ");
        }

        private void RemoveNode(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Usuwasz noda: ");
        }
    }
}
