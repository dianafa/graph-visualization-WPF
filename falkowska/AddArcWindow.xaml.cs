﻿using System;
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
        public AddArcWindow(Dictionary<string, Node<City>> nodes)
        {
            InitializeComponent();
            lbDestNode.ItemsSource = nodes;
            lbSrcNode.ItemsSource = nodes;
        }

        private void SaveArc(object sender, RoutedEventArgs e)
        {
            if (lbSrcNode.SelectedItem == lbDestNode.SelectedItem)
            {
                MessageBox.Show("Cannot add arc from " + lbSrcNode.SelectedItem.ToString() + " to " + lbDestNode.SelectedItem.ToString() + "!");
            }
            else
            {
                KeyValuePair<string, Node<City>> kwp1 = (KeyValuePair<string, Node<City>>)lbSrcNode.SelectedItem;
                KeyValuePair<string, Node<City>> kwp2 = (KeyValuePair<string, Node<City>>)lbDestNode.SelectedItem;
                MessageBox.Show("Dodaje luk z " + kwp1.Key + " do " + kwp2.Key);
                string result = kwp1.Value.AddArc(kwp2.Value);
                MessageBox.Show(result);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
