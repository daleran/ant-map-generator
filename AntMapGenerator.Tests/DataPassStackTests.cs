using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AntMapGenerator;

namespace AntMapGenerator.Tests
{
    public class DataPassStackTests
    {
        


        [Test]
        public void DataPassStackRunPipeline()
        {
            var go = new GameObject("Test");
            var layers = new DataLayer[] {MockObjects.CreateMockDataLayer(10,10), MockObjects.CreateMockDataLayer(10, 10) };
            var passes = new BaseDataPass[] {MockObjects.CreateMockDataPass(go,layers,5), MockObjects.CreateMockDataPass(go, layers, 10) };
            var stack = go.AddComponent<DataPassStack>();
            stack.Passes = passes;
            stack.Run();

            foreach(BaseDataPass pass in passes)
            {

            }

        }

    }
}
