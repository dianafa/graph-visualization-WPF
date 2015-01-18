using GraphLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGraph
{
    public class City : Node<City>
    {
        public string county;
        string population { get; set; }

        public City(string name, string county, string population)
        {
            this.name = name;
            this.county = county;
            this.population = population;
        }
    }

}
