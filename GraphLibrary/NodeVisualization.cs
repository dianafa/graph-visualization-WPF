using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphLibrary
{
    public class NodeVisualization<T> : Node<T>
    {
        public double x;
        public double y;
        public Ellipse ellipse;

        public NodeVisualization (string name)
        {
            // Create a red Ellipse.
            Ellipse myEllipse = new Ellipse();

            // Create a SolidColorBrush with a red color to fill the 
            // Ellipse with.
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();

            // Describes the brush's color using RGB values. 
            // Each value has a range of 0-255.
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            myEllipse.Fill = mySolidColorBrush;
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.Black;

            // Set the width and height of the Ellipse.
            myEllipse.Width = 50;
            myEllipse.Height = 50;

            //ellipse.Style = (Style)ellipse.TryFindResource("NodeStyle");
            this.ellipse = myEllipse;

            var rnd = new Random(DateTime.Now.Millisecond);
            int x = rnd.Next(0, 400);
            int y = rnd.Next(0, 300);
            this.x = x;
            this.y = y;
            this.name = name;
        }
    }
}
