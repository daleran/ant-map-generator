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
        MapDefinition def;

        [Test]
        public void DataLayerIsSetToConstantValue()
        {
            def = ScriptableObject.CreateInstance<MapDefinition>();
            data = ScriptableObject.CreateInstance<DataLayer>();
            def.Initialize(10, 10);
            data.Definition = def;
            data.ResetData();

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
