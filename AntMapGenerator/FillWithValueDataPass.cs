using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    public class FillWithValueDataPass : MonoBehaviour, IDataPass
    {

        [SerializeField]
        DataLayer[] layers;
        public DataLayer[] Layers { get => layers;  set => layers = value; }

        [SerializeField]
        int valueToPopulate;
        public int ValueToPopulate { get => valueToPopulate; set => valueToPopulate = value; }
        
        [SerializeField]
        IDataPass next;
        public IDataPass Next { get => next; set => next = value; }

        public void Run()
        {
            for (int i=0;i<Layers.Length;i++)
            {
                PopulateLayer(Layers[i], valueToPopulate);
            }

            Next.Run();
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
        }


    }

}