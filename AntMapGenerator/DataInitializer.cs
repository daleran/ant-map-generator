using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    public class DataInitializer : BaseDataPass
    {
        public override void Run()
        {
            foreach (DataLayer layer in Layers)
            {
                layer.ResetData();
            }
        }
    }

}
