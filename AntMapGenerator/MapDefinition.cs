using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewMapDefinition", menuName = "Ant Map Generator/Map Definition", order = 361)]
    public class MapDefinition
    {
        [SerializeField]
        Vector2Int center;

        [SerializeField]
        Vector2Int size;

        [SerializeField]
        [TextArea()]
        string description;

        private BoundsInt bounds;

        void OnValidate()
        {
            bounds = new BoundsInt(center.x, center.y, size.x, size.y, 1, 1);
            Debug.Log("Created");
        }
    }
}

