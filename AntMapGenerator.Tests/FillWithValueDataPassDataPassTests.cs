using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AntMapGenerator;

namespace AntMapGenerator.Tests
{
    public class FillWithValueDataPassTests
    {
        DataLayer data;

        [Test]
        public void DataLayerIsSetToConstantValue()
        {
            data = ScriptableObject.CreateInstance<DataLayer>();
            data.Initialize(10, 10);

            var go = new GameObject("Test");
            var pass = go.AddComponent<FillWithValueDataPass>();
            pass.Layers = new DataLayer[] { data };
            pass.ValueToPopulate = 5;
            pass.Run();

            for (int x = 0; x < data.SizeX; x++)
            {
                for (int y = 0; y < data.SizeY; y++)
                {
                    Assert.That(data[x, y], Is.EqualTo(5));
                }
            }
        }
    }
}
