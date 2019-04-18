using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    public class RunDataPasses : MonoBehaviour
    {
        [SerializeField]
        DataLayer[] layers;

        [SerializeField]
        BaseDataPass[] passes;
        
        // Start is called before the first frame update
        void Start()
        {
            Run();
        }

        [ContextMenu("Run")]
        public void Run()
        {
            foreach (DataLayer layer in layers)
            {
                layer.ResetData();
            }

            foreach (BaseDataPass pass in passes)
            {
                pass.Run();
            }
        }

    }

}
