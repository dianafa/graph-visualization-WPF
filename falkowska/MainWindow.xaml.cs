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
    public partial class MainWindow : Window
    {
        public Graph<City> cityGraph;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            cityGraph = new Graph<City>();
            cityGraph["Poznan"] = new City("Poznan", "wielkopolskie", "547tys.");
            cityGraph.AddNode(new City("Krakow", "wielkopolskie", "647tys."));
            //MessageBox.Show("cityGraph.nodes[0]: " + cityGraph.nodes["Poznan"]);
            lbNodes.ItemsSource = cityGraph.nodes;
        }

        public Graph<City> getGraph() 
        {
            return this.cityGraph;
        }

        private void MainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }
        private void AddNode(object sender, RoutedEventArgs e)
        {
            Node<City> new_node = new City(NameInput.Text, CountyInput.Text, PopulationInput.Text);
            string info = cityGraph.AddNode(new_node);
            MessageBox.Show(info);
            lbNodes.ItemsSource = null;
            lbNodes.ItemsSource = cityGraph.nodes;
            foreach (NodeVisualization<City> v_node in cityGraph.visualized_nodes)
            {
                Canvas.SetTop(v_node.ellipse, v_node.y);
                Canvas.SetLeft(v_node.ellipse, v_node.x);
                v_node.ellipse.Name = v_node.name;
                v_node.ellipse.MouseUp += ellipse_MouseUp;
                canvas.Children.Add(v_node.ellipse);
            }
        }

        private void ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("City: " + ((FrameworkElement)e.Source).Name);
        }

        private void EditNode(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edytujesz noda: "+ lbNodes.SelectedItem);

        }

        private void RemoveNode(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Czy na pewno chcesz usunac: " + lbNodes.SelectedItem + "?");
        }

        private void AddArc(object sender, RoutedEventArgs e)
        {
            /*if (lbNodes.SelectedItem != null)
            {
                MessageBox.Show("Dodajesz luk z: " + lbNodes.SelectedItem + ". Wybierz destynacje i kliknij przycisk ponownie.");
            }
            else {
                MessageBox.Show("Select node you want to add arc to");
            }*/
            var newWindow = new AddArcWindow();
            newWindow.Show();

        }

        private void RunAlgorithm(object sender, RoutedEventArgs e)
        {
            if (radioDFS.IsChecked == true)
            {
                MessageBox.Show("Uruchamiasz algorytm: " + radioDFS.Content);
                IEnumerable<Node<City>> wynik = cityGraph.DFS(cityGraph.nodes["Poznan"]);
                MessageBox.Show("Wynik: " + wynik);
                return;
            }
            if (radioBFS.IsChecked == true)
            {
                MessageBox.Show("Uruchamiasz algorytm: " + radioBFS.Content);
                return;
            }
            MessageBox.Show("Wybierz opcje!");
            
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            
        }

        private void canvas_DragEnter(object sender, DragEventArgs e)
        {
            
        }
    }
}
