using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    public class ConstantValueDataPass : MonoBehaviour, IDataPass
    {
        [SerializeField]
        DataLayer[] layers;
        [SerializeField]
        int value;

        public void Run()
        {
            
        }


    }

}