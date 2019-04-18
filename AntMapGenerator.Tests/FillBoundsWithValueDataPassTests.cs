using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AntMapGenerator;

namespace Tests
{
    public class FillBoundsWithValueDataPassTests
    {
        DataLayer data;
        MapDefinition def;

        [Test]
        public void DataLayerIsSetToConstantValue()
        {
            def = ScriptableObject.CreateInstance<MapDefinition>();
            data = ScriptableObject.CreateInstance<DataLayer>();
            def.Initialize(4, 4);
            data.Definition = def;
            data.ResetData();

            var go = new GameObject("Test");
            var fillPass = go.AddComponent<FillWithValueDataPass>();
            fillPass.Layers = new DataLayer[] { data };
            fillPass.ValueToPopulate = 5;
            fillPass.Run();

            var bndsPass = go.AddComponent<FillBoundsWithValueDataPass>();
            bndsPass.Layers = new DataLayer[] { data };
            bndsPass.ValueToPopulate = 10;
            bndsPass.Bounds = new BoundsInt(new Vector3Int(0,0,-157),new Vector3Int(2,2,160));
            bndsPass.Run();

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    Assert.That(data[x, y], Is.EqualTo(10));
                }
            }

            for (int x = 2; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Assert.That(data[x, y], Is.EqualTo(5));
                }
            }

            for (int x = 0; x < 2; x++)
            {
                for (int y = 2; y < 4; y++)
                {
                    Assert.That(data[x, y], Is.EqualTo(5));
                }
            }

        }
    }
}
