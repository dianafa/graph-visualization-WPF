using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace GraphLibrary
{
    public class Graph<T> : IEnumerable<Node<T>>
    {
        public Dictionary<string, Node<T>> nodes = new Dictionary<string, Node<T>>();

        public Node<T> this[string index]
        {
            get
            {
                return nodes[index];
            }
            set
            {
                nodes[index] = new Node<T> (value.name, value.type, value);
            }
        }

        public bool AddNode(Node<T> node)
        {
            if (node.name == null) return false;
            if (nodes.ContainsKey(node.name)) {
                return false;
            };
            Node<T> graphNode = new Node<T> (node.name,node.GetType(), node);
            nodes.Add(node.name, graphNode);
            return true;
        }

        //Implementation of IEnumberable interface
        #region IEnumerable<Node<T>> Members
 
        public IEnumerator<Node<T>> GetEnumerator()
        {
            foreach (KeyValuePair<string, Node<T>> node in nodes)
            {
                if (node.Key == null)
                {
                    break;
                }
                yield return node.Value;
            }
        }
        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        public LinkedList<Node<T>> GetNeighbours(Node<T> node) 
        {
            return node.arcsOut;
        }

        public IEnumerable<Node<T>> DFS(Node<T> start)
        {
            var visited = new HashSet<Node<T>>();
            var stack = new Stack<Node<T>>();

            stack.Push(start);

            while(stack.Count != 0)
            {
                var current = stack.Pop();

                if (!visited.Add(current))
                    continue;

                yield return current;

                var neighbours = this.GetNeighbours(current).Where(n => !visited.Contains(n));

                foreach (var neighbour in neighbours.Reverse())
                    stack.Push(neighbour);
            }
        }
    }

}
