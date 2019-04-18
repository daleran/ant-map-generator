using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AntMapGenerator.Tests
{
    public class MapDefinitionTests
    {
        [Test]
        [TestCase(-1, 2, ExpectedResult = false)]
        [TestCase(3, -1, ExpectedResult = false)]
        [TestCase(10, 2, ExpectedResult = false)]
        [TestCase(2, 10, ExpectedResult = false)]
        [TestCase(0, 0, ExpectedResult = true)]
        [TestCase(9, 9, ExpectedResult = true)]
        public bool ContainsTest(int x, int y)
        {
            var def = ScriptableObject.CreateInstance<MapDefinition>();
            def.Initialize(10, 10);
            return def.Contains(x, y);
        }


    }
}
