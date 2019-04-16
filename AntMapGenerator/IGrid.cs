using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator
{
    public interface IGrid<T>
    {
        T this[Vector3Int coord] { get; set; }
    }
}
