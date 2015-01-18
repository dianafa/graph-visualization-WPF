using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    class NodeVisualization<T> : Node<T>
    {
        public double x;
        public double y;

        public bool Paint()
        {
            return true;
        }
    }
}
