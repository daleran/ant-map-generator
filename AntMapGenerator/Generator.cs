using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AntMapGenerator.Utilities;

namespace AntMapGenerator
{
    [ExecuteInEditMode]
    public class Generator : MonoBehaviour
    {
        [SerializeField]
        int sizeX;
        public int SizeX { get => sizeX; }

        [SerializeField]
        int sizeY;
        public int SizeY { get => sizeY; }

        [ContextMenu("Generate Data Layers")]
        void GenerateDataLayers()
        {
            IDataPass[] passes = gameObject.GetComponentsInChildren<IDataPass>();
            System.Array.Sort(passes, delegate(IDataPass l, IDataPass r) { return l.Priority.CompareTo(r.Priority); } );

            HashSet<DataLayer> layers = new HashSet<DataLayer>();

            for (int i=0; i < passes.Length; i++)
            {
                for (int j= 0; j < passes[i].Layers.Length; j++)
                {
                    layers.Add(passes[i].Layers[j]);
                }
            }

            foreach(DataLayer dl in layers)
            {
                dl.Initialize(SizeX, SizeY);
            }

            for (int i = 0; i < passes.Length; i++)
            {
                passes[i].Run();
            }

        }

    } 
}
