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
        public LinkedList<Node<T>> arcsOut = new LinkedList<Node<T>>();

        public string AddArc(Node<T> destination)
        {
            try
            {
                arcsOut.AddLast(destination);
                Console.WriteLine("Luki z : ", this.name);
                foreach (Node<T> k in arcsOut) {
                    Console.WriteLine("k: ", k.name);
                }
                
                return arcsOut.Last().name;
            }
            catch (NullReferenceException)
            {
                return "NullReferenceException";
            }
            
        }
    }




}
