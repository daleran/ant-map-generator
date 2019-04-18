using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    public class FillWithValueDataPass : BaseDataPass
    {
          
        [SerializeField]
        int valueToPopulate;
        public int ValueToPopulate { get => valueToPopulate; set => valueToPopulate = value; }
        
        public override void Run()
        {
            for (int i=0;i<Layers.Length;i++)
            {
                PopulateLayer(Layers[i], valueToPopulate);
            }

            base.Run();
        }

        private void PopulateLayer(DataLayer layer, int value)
        {
            for(int x=0;x < layer.SizeX; x++)
            {
                for(int y=0; y < layer.SizeY; y++)
                {
                    layer[x, y] = value;
                }
            }
            Debug.Log("Running Fill Value");
            layer.DebugPrintToConsole();
        }
    }
}