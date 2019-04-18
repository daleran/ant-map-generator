using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewMapDefinition", menuName = "Ant Map Generator/MapDefinition", order = 361)]
    public class MapDefinition : ScriptableObject
    {
        [SerializeField]
        int sizeX;
        public int SizeX { get => sizeX; }

        [SerializeField]
        int sizeY;
        public int SizeY { get => sizeY; }

        [SerializeField]
        [TextArea()]
        string description;

        public BoundsInt Bounds { get => new BoundsInt(0, 0, 0, SizeX, SizeY, 1); }

        public void Initialize(int x, int y)
        {
            sizeX = x;
            sizeY = y;
        }
        
        public bool Contains (int x, int y)
        {
            if (x < 0 || x >= sizeX || y < 0 || y >= sizeY)
                return false;

            return true;
        }

        
    }
}

