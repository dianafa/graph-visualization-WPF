using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//g.DFS(
//ma zwrocic posortowanie elementow grafu zgodne z DFS
//uzytkownik nie musi wiedziec co zostanie zwrocone, ale wie, ze moze po tym iterowac 
//(lista, tablica) zeby dzieczyla z IEnumerable

namespace GraphLibrary
{
    public class Node<T> 
    {
        public string name;
        public Type type;
        public LinkedList<Node<T>> arcsOut;

        public void AddArc(Node<T> destination)
        {
            /*try
            {
                arcsOut.AddLast(destination);
            }
            catch (NullReferenceException)
            {
                int a;
            }*/
            Node<T> n = new Node<T> { name = destination.name };
            //n = destination;
            //arcsOut.AddLast(new Node<T> { name = destination.name });
            
        }
    }




}
