using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    [ExecuteInEditMode]
    public abstract class BaseDataPass : MonoBehaviour
    {
        [SerializeField]
        DataLayer[] layers;
        public virtual DataLayer[] Layers { get => layers; set => layers = value; }

        [ContextMenu("Run")]
        public virtual void Run()
        {

        }
    }

}
