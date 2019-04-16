using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    [System.Serializable]
    public class MapData : IGrid<int>
    {
        readonly string[] layerNames;
        readonly int[,,] data;
        readonly int sizeX;
        readonly int sizeY;

        public int this[Vector3Int coord]
        {
            get { return data[coord.x, coord.y, coord.z]; }
            set { data[coord.x, coord.y, coord.z] = value; }
        }

        public int this[string layer, Vector2Int coord]
        {
            get { return data[coord.x, coord.y, LayerID(layer)]; }
            set { data[coord.x, coord.y, LayerID(layer)] = value; }
        }

        public MapData(string[] layerNames, int sizeX, int sizeY)
        {
            this.layerNames = layerNames;
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            data = new int[sizeX, sizeY, layerNames.Length];
        }

        public string LayerName (int id)
        {
            return layerNames[id];
        }

        public int LayerID(string name)
        {
            for (int i = 0; i < layerNames.Length; i++)
            {
                if (layerNames[i] == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool CheckBounds (int x, int y)
        {
            if (x < 0 || x >= sizeX || y < 0 || y >= sizeY)
                return false;

            return true;
        }

    }

}
