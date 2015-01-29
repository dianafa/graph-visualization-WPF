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
            testGraph["Bydgoszcz"] = new City("Bydgoszcz", "kuj-pom", "300tys.");
            testNode.AddArc(testGraph["Bydgoszcz"]);

            Assert.AreEqual(1, testNode.arcsOut.Count, "arcsOut list didn't change");
            Assert.AreEqual(testGraph["Bydgoszcz"], testNode.arcsOut[0]);
            Assert.AreEqual(testGraph["Bydgoszcz"].name, testNode.arcsOut[0].name, "arcsOut[0].name is not the added node.name");
            Assert.AreEqual(testGraph["Bydgoszcz"].properties["county"], testNode.arcsOut[0].properties["county"], "arcsOut[0].county is not the added nodecounty");
        }
    }
}
