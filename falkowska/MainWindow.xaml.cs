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
        private AddArcWindow arcWindow;
        public List<NodeVisualization<City>> visualized_nodes;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            visualized_nodes = new List<NodeVisualization<City>>();
            cityGraph = new Graph<City>();
            ///**** add node ****
            cityGraph["Poznan"] = new City("Poznan", "wielkopolskie", "547tys.");
            AddNode_Canvas("Poznan");
            cityGraph.AddNode(new City("Krakow", "wielkopolskie", "647tys."));
            AddNode_Canvas("Krakow");

            lbNodes.ItemsSource = cityGraph.nodes;
        }

        private void MainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void AddNode_Click(object sender, RoutedEventArgs e)
        {
            string name = (NameInput.Text.Trim() == null) ? NameInput.Text : randomNodeName();
            Node<City> new_node = new City(name, CountyInput.Text, PopulationInput.Text);
            bool success = cityGraph.AddNode(new_node);
            if (success)
            {
                lbNodes.ItemsSource = null;
                lbNodes.ItemsSource = cityGraph.nodes;
                AddNode_Canvas(name);
            }
        }

        private void AddNode_Canvas(string name)
        {
            NodeVisualization<City> new_node = new NodeVisualization<City>(name);
            //MessageBox.Show("v_node: " + new_node);
            visualized_nodes.Add(new_node);

            //MessageBox.Show("updateCanvas, ile nodow: "+ visualized_nodes.Count);

            Canvas.SetTop(new_node.ellipse, new_node.y);
            Canvas.SetLeft(new_node.ellipse, new_node.x);
            new_node.ellipse.Name = new_node.name;
            new_node.ellipse.MouseUp += ellipse_MouseDown;
            new_node.ellipse.MouseMove += ellipse_MouseMove;
            new_node.ellipse.MouseEnter += ellipse_MouseEnter;
            new_node.ellipse.MouseLeave += ellipse_MouseLeave;
            new_node.ellipse.MouseRightButtonDown += ellipse_MouseRightButtonDown;
            canvas.Children.Add(new_node.ellipse);
        }

        void ellipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Rightclick on: "+ sender.ToString());
            Ellipse ellipse = (Ellipse)sender;
        }

        void ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            ((Ellipse)e.Source).Fill = mySolidColorBrush;
        }

        void ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            Ellipse ell = ((Ellipse)e.Source);
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 0, 255, 0);
            ell.Fill = mySolidColorBrush;
            ell.ToolTip = ell.Name;
            
        }

        private void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string name = ((Ellipse)e.Source).Name;
            Node<City> node = cityGraph[name];
            MessageBox.Show("City: " + node.name + " Typ: " + node.GetType());
        }

        private void EditNode_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edytujesz noda: "+ lbNodes.SelectedItem);
        }

        private void RemoveNode_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Czy na pewno chcesz usunac: " + lbNodes.SelectedItem + "?");
        }

        private void AddArc_Click(object sender, RoutedEventArgs e)
        {
            /*if (lbNodes.SelectedItem != null)
            {
                MessageBox.Show("Dodajesz luk z: " + lbNodes.SelectedItem + ". Wybierz destynacje i kliknij przycisk ponownie.");
            }
            else {
                MessageBox.Show("Select node you want to add arc to");
            }*/
            //var newWindow = new AddArcWindow();
            arcWindow = new AddArcWindow(cityGraph.nodes);
            arcWindow.Owner = this;
            arcWindow.Show();
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

        //protected override void OnMouseMove(object sender, MouseEventArgs e)
        private void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //MessageBox.Show("Started to move from " + e.GetPosition(canvas).ToString());
                Ellipse ellipse = sender as Ellipse;
                if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
                {
                    DataObject data = new DataObject();
                    //data.SetData(DataFormats.StringFormat, ellipse.Fill.ToString());
                    //data.SetData("Double", ellipse.Height);
                    data.SetData("Object", ellipse);

                    DragDrop.DoDragDrop(this,
                                         data,
                                         DragDropEffects.Move);
                }
            }
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            Canvas c = sender as Canvas;

            if (c != null)
            {
                // If an element in the panel has already handled the drop, 
                // the panel should not also handle it. 
                if (e.Handled == false)
                {
                    Ellipse _element = (Ellipse)e.Data.GetData("Object");
                    if (c != null && _element != null)
                    {
                        if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            c.Children.Remove(_element);
                            //zmien pozycje
                            System.Windows.Point position = e.GetPosition(canvas);
                            Canvas.SetTop(_element, position.Y);
                            Canvas.SetLeft(_element, position.X);
                            c.Children.Add(_element);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
            }
        }

        private void canvas_DragEnter(object sender, DragEventArgs e)
        {
            /*if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                MessageBox.Show("jest strib");
                //e.Effects = DragDropEffects.Copy;
            }
            else
            {
                MessageBox.Show("nie ma pola string");
                e.Effects = DragDropEffects.None;
            }*/
        }

        private string randomNodeName()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZAAAAA";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> data = new List<string>();
            data.Add("Book");
            data.Add("Computer");
            data.Add("Chair");
            data.Add("City");

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.Title = value + " Graph by dianafa";
        }
    }
}
