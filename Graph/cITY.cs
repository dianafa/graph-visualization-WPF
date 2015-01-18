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
        string county;
        string population;

        public City(string name, string county, string population)
        {
            this.name = name;
            this.county = county;
            this.population = population;
        }
    }

}
