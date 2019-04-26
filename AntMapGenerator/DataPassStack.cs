using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    public class DataPassStack : BaseDataPass
    {
        [SerializeField]
        BaseDataPass[] passes;
        public BaseDataPass[] Passes { get => passes; set => passes = value; }

        public override void Run()
        {

            foreach (BaseDataPass pass in passes)
            {
                pass.Run();
            }
        }
    }
}
