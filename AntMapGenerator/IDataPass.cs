using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AntMapGenerator.Utilities;

namespace AntMapGenerator
{
    public interface IDataPass
    {
        void Run();
        DataLayer[] Layers { get; }
        IDataPass Next { get; }
    }
}

