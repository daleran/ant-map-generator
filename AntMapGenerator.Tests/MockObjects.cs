using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator.Tests
{
    public class MockObjects
    {
        public static DataLayer CreateMockDataLayer(int sizeX, int sizeY)
        {
            DataLayer mockLayer = ScriptableObject.CreateInstance<DataLayer>();
            mockLayer.Definition = ScriptableObject.CreateInstance<MapDefinition>();
            mockLayer.Definition.Initialize(sizeX, sizeY);
            mockLayer.ResetData();
            return mockLayer;
        }

        public static FillWithValueDataPass CreateMockDataPass(GameObject parent, DataLayer[] layers, int fillValue)
        {
            var pass = parent.AddComponent<FillWithValueDataPass>();
            pass.Layers = layers;
            pass.ValueToPopulate = fillValue;
            return pass;
        }
    }
}

