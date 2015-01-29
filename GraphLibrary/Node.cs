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
        public Dictionary<string, string> properties;
        public List<Node<T>> arcsOut;

        public Node (string name, Type type, Object obj)
        {
            this.name = name;
            this.type = type;
            this.properties = setProperties(obj);
            arcsOut = new List<Node<T>>();
        }

        public Node()
        {
            this.name = null;
            this.type = null;
            this.properties = null;
            arcsOut = new List<Node<T>>();
        }

        public Dictionary<string, string> setProperties(Object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine("TYPE: ", type);

            Dictionary<string, string> result = new Dictionary<string,string>();

            foreach (var f in type.GetFields().Where(f => f.IsPublic)) {
                if ((f.Name != "type") && (f.Name != "properties") && (f.Name != "arcsOut"))
                {
                    Console.WriteLine(
                    String.Format("Name: {0} Value: {1}", f.Name, f.GetValue(obj)));
                    result.Add(f.Name, f.GetValue(obj).ToString());
                }
            }

            return result;
        }

        public string AddArc(Node<T> destination)
        {
            try
            {
                arcsOut.Add(destination);
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
