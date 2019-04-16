﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AntMapGenerator;


namespace AntMapGenerator.Tests
{
    public class DataLayerTests
    {
        DataLayer data;

        [SetUp]
        public void Setup()
        {
            data = ScriptableObject.CreateInstance<DataLayer>();
            data.Initialize(10, 10);
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
        [TestCase(5, 5, 2, ExpectedResult = 2)]
        [TestCase(0, 0, 2, ExpectedResult = 2)]
        [TestCase(9, 5, 2, ExpectedResult = 2)]
        [TestCase(5, 9, 2, ExpectedResult = 2)]
        public int SetAndRetrieveValuesVector(int x, int y, int value)
        {
            Vector2Int coord = new Vector2Int(x, y);
            data[coord] = value;
            return data[coord];
        }

        [Test]
        [TestCase(5, 0, 2, ExpectedResult = 2)]
        [TestCase(2, 3, 2, ExpectedResult = 2)]
        public int SetAndRetrieveValuesIndexer(int x, int y, int value)
        {
            data[x,y] = value;
            return data[x,y];
        }

        [Test]
        public void IndexOffMapBoundsByVector2()
        {
            Vector2Int coord = new Vector2Int(3, 10);
            Assert.That(() => data[coord] = -457, Throws.TypeOf<System.IndexOutOfRangeException>());
        }

        [Test]
        public void IndexOffMapBoundsIndexer()
        {
            Assert.That(() => data[10, 3] = 5, Throws.TypeOf<System.IndexOutOfRangeException>());
        }


    }
}