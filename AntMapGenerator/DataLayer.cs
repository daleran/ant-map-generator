using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewDataLayer", menuName = "Ant Map Generator/DataLayer", order = 362)]
    public class DataLayer : ScriptableObject
    {

        [SerializeField]
        MapDefinition definition;
        public MapDefinition Definition { get => definition; set => definition = value; }

        public int SizeX { get => definition.SizeX; }
        public int SizeY { get => definition.SizeY; }
        public BoundsInt Bounds { get => definition.Bounds; }

        int[,] data;

        public int this[int x, int y]
        {
            get { return data[x, y]; }
            set { data[x, y] = value; }
        }

        public int this[Vector2Int coord]
        {
            get { return this[coord.x, coord.y]; }
            set { this[coord.x, coord.y] = value; }
        }

        public bool Contains(int x, int y)
        {
            return definition.Contains(x, y);
        }

        public void ResetData()
        {
            data = new int[definition.SizeX,definition.SizeY];
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine(name);

            for (int y = SizeY-1; y > -1; y--)
            {
                sb.Append("[ ");
                for (int x = 0; x < SizeX; x++)
                {
                    sb.Append(this[x, y]+" ");
                }
                sb.AppendLine("]");
            }

            return sb.ToString();
        }

        [ContextMenu("Debug Print")]
        public void DebugPrintToConsole()
        {
            Debug.Log(ToString());
        }
    }
}

