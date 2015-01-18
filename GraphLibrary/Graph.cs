﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public class Graph<T> : IEnumerable<Node<T>>
    {
        //int arcCount = 0;
        public Dictionary<string, Node<T>> nodes = new Dictionary<string, Node<T>>(); //nie jestem pewna co do tego

        public Node<T> this[string index]
        {
            get
            {
                return nodes[index];
            }
            set
            {
                nodes[index] = value;
            }
        }

        public string AddNode(Node<T> node)
        {
            //TODO: opakuj go w klase node i dodaj. CHYBA INTERFEJS BY SIE PRZYDAL
            if (nodes.ContainsKey(node.name)) {
                return "This node already exists!";
            };
            Node<T> graphNode = new NodeVisualization<T>();
            graphNode.name = node.name;
            graphNode.type = node.GetType();
            nodes.Add(node.name, graphNode);
            //rysuj!
           ((NodeVisualization<T>)graphNode).Paint();
            return "Node was added";
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
