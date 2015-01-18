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
using System.Windows.Shapes;
using GraphLibrary;
using CityGraph;

namespace falkowska
{
    /// <summary>
    /// Interaction logic for AddArc.xaml
    /// </summary>
    public partial class AddArcWindow : Window
    {
        MainWindow bigWindow;
        public AddArcWindow()
        {
            InitializeComponent();

            bigWindow = new MainWindow();
            lbDestNode.ItemsSource = bigWindow.getGraph().nodes;
            lbSrcNode.ItemsSource = bigWindow.getGraph().nodes;
        }

        private void SaveArc(object sender, RoutedEventArgs e)
        {
            if (lbSrcNode.SelectedItem == lbDestNode.SelectedItem)
            {
                MessageBox.Show("Cannot add arc from " + lbSrcNode.SelectedItem + " to " + lbDestNode.SelectedItem + "!");
            }
            else
            {
                MessageBox.Show("Dodaje luk z " + lbSrcNode.SelectedItem + " do " + lbDestNode.SelectedItem);
                bigWindow.cityGraph.nodes["Poznan"].AddArc(bigWindow.cityGraph.nodes["Krakow"]);
                MessageBox.Show("Arcs: " + bigWindow.cityGraph.nodes["Poznan"].arcsOut.Last);
                //bigWindow.getGraph().nodes[lbSrcNode.SelectedItem.ToString].AddArc(bigWindow.getGraph().nodes[lbDestNode.SelectedItem.ToString]);
            }
        }
    }
}
