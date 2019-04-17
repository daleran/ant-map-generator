using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewDataLayer", menuName = "Ant Map Generator/DataLayer", order = 362)]
    public class DataLayer : ScriptableObject
    {


        int[,] data;
        int sizeX;
        public int SizeX { get => sizeX; }
        int sizeY;
        public int SizeY { get => sizeY; }

        public int this[Vector2Int coord]
        {
            get { return this[coord.x, coord.y]; }
            set { this[coord.x, coord.y] = value; }
        }

        public int this [int x, int y]
        {
            get { return data[x, y]; }
            set { data[x, y] = value; }
        }

        public void Initialize(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            data = new int[sizeX, sizeY];
        }

        public bool CheckBounds(int x, int y)
        {
            if (x < 0 || x >= sizeX || y < 0 || y >= sizeY)
                return false;

            return true;
        }

    }
}

