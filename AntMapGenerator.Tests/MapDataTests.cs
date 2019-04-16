using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AntMapGenerator;


namespace AntMapGenerator.Tests
{
    public class MapDataTests
    {
        MapData data;

        [SetUp]
        public void Setup()
        {
            data = new MapData(new string[] { "Test1", "Test2" }, 10, 10);
        }

        [Test]
        [TestCase(-1, 2, ExpectedResult = false)]
        [TestCase(3, -1, ExpectedResult = false)]
        [TestCase(10, 2, ExpectedResult = false)]
        [TestCase(2, 10, ExpectedResult = false)]
        [TestCase(0, 0, ExpectedResult = true)]
        [TestCase(9, 9, ExpectedResult = true)]
        public bool CheckBoundsTest(int x, int y)
        {
            return data.CheckBounds(x, y);
        }

        [Test]
        [TestCase("BadName", ExpectedResult = -1)]
        [TestCase("test1", ExpectedResult = -1)]
        [TestCase("Test1", ExpectedResult = 0)]
        [TestCase("Test2", ExpectedResult = 1)]
        public int LayerNameToIDTest(string layer)
        {
            return data.LayerID(layer);
        }

        [Test]
        [TestCase(5,5,0, 2, ExpectedResult = 2)]
        [TestCase(0, 0, 0, 2, ExpectedResult = 2)]
        [TestCase(9, 5, 0, 2, ExpectedResult = 2)]
        [TestCase(5, 9, 0, 2, ExpectedResult = 2)]
        public int SetAndRetrieveValues(int x, int y, int z, int value)
        {
            Vector3Int coord = new Vector3Int(x, y, z);
            data[coord] = value;
            return data[coord];
        }

        [Test]
        [TestCase("Test1", 5, 0, 2, ExpectedResult = 2)]
        [TestCase("Test2", 2, 3, 2, ExpectedResult = 2)]
        public int SetAndRetrieveValuesByName(string layer, int x, int y, int value)
        {
            Vector2Int coord = new Vector2Int(x, y);
            data[layer, coord] = value;
            return data[layer,coord];
        }

        [Test]
        public void IndexOffMapBoundsVector3()
        {
            Vector3Int coord = new Vector3Int(14,3,0);
            Assert.That(() => data[coord] = 5, Throws.TypeOf<System.IndexOutOfRangeException>());
        }

        [Test]
        public void IndexWrongLayerVector3()
        {
            Vector3Int coord = new Vector3Int(9, 3, 3);
            Assert.That(() => data[coord] = 692, Throws.TypeOf<System.IndexOutOfRangeException>());
        }

        [Test]
        public void IndexOffMapBoundsByVector2()
        {
            Vector2Int coord = new Vector2Int(3, 11);
            Assert.That(() => data["Test1",coord] = -457, Throws.TypeOf<System.IndexOutOfRangeException>());
        }

        [Test]
        public void IndexWithWrongLayerName()
        {
            Vector2Int coord = new Vector2Int(5, 5);
            Assert.That(() => data["test2",coord] = -5, Throws.TypeOf<System.IndexOutOfRangeException>());
        }

    }
}
