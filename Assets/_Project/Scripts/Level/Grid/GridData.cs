using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    [Serializable]
    public class GridData
    {
        [SerializeField] private float _cellOffset = 3.2f;
        [SerializeField] private List<GridLine> _gridLines;

        public float CellOffset => _cellOffset;
        public IReadOnlyList<GridLine> GridLines => _gridLines;

        public void SetGrid(List<GridLine> gridLines)
        {
            _gridLines = gridLines;
        }
    }

    [Serializable]
    public struct GridLine
    {
        [SerializeField] private List<CellInfo> _cells;

        public IReadOnlyList<CellInfo> Cells => _cells;

        public GridLine(List<CellInfo> cellInfos)
        {
            _cells = cellInfos;
        }
    }
}