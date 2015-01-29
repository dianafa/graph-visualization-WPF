using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityGraph;
using GraphLibrary;

namespace GraphLibraryTest
{
    [TestClass]
    public class NodeTests
    {
        Graph<City> testGraph;
        Node<City> testNode;
        [TestInitialize()]
        public void Initialize()
        {
            Console.WriteLine("TestMethodInit");
            testGraph = new Graph<City>();
            testNode = new City("Krakow", "wielkopolskie", "647tys.");
            testGraph.AddNode(testNode);
        }

        [TestMethod]
        public void TestAddArc_correct()
        {
            Node<City> node1 = new City("Bydgoszcz", "kuj-pom", "300tys.");
            testGraph.AddNode(node1);

            testNode.AddArc(node1);

            Assert.AreEqual(1, testNode.arcsOut.Count, "arcsOut list didn't change");
            Assert.AreEqual(node1, testNode.arcsOut[0]);
            Assert.AreEqual(node1.name, testNode.arcsOut[0].name, "arcsOut[0].name is not the added node.name");
            Console.WriteLine("node1.properties" + node1.properties);
            Console.WriteLine("node1.name" + node1.name);
            //Console.WriteLine("testNode.arcsOut[0].properties[county" + testNode.arcsOut[0].properties["county"]);
            //Assert.AreEqual(node1.properties["county"], testNode.arcsOut[0].properties["county"], "arcsOut[0].county is not the added nodecounty");

        }
    }
}
