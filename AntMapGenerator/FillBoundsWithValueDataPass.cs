using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    public class FillBoundsWithValueDataPass : BaseDataPass
    {
        [Header("Note: This bounds will ignore z and auto clamp to the dataLayer")]
        [SerializeField]
        BoundsInt bounds;
        public BoundsInt Bounds { get => bounds; set => bounds = value; }

        [SerializeField]
        int valueToPopulate;
        public int ValueToPopulate { get => valueToPopulate; set => valueToPopulate = value; }

        public override void Run()
        {
            for (int i = 0; i < Layers.Length; i++)
            {
                PopulateLayer(Layers[i], bounds, ValueToPopulate);
            }

            base.Run();
        }

        private void PopulateLayer(DataLayer layer, BoundsInt bounds, int value)
        {
            bounds.ClampToBounds(layer.Bounds);

            for (int x = bounds.xMin; x < bounds.xMax;x++)
            {
                for (int y = bounds.yMin; y < bounds.yMax; y++)
                {
                    layer[x, y] = value;
                }
            }
        }
    }
}

