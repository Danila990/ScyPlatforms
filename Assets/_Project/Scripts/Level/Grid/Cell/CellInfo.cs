using System;
using UnityEngine;

namespace MyCode
{
    [Serializable]
    public struct CellInfo
    {
        [field: SerializeField] public Vector2Int CellIndex { get; private set; }
        [field: SerializeField] public CellType CellType { get; private set; }

        public CellInfo(Vector2Int cellIndex, CellType cellType)
        {
            CellIndex = cellIndex;
            CellType = cellType;
        }
    }
}