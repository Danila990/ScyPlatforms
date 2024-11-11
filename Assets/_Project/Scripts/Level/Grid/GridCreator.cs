using MyCode.Core;
using System;
using UnityEditor;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode
{
    public class GridCreator : MonoBehaviour, IStartable
    {
        [SerializeField] private Transform _parrent;

        private IObjectFactory _factory;
        private GridData _gridData;

        private Cell[][] _cells;

        [Inject]
        public void Construct(IObjectFactory factory, LevelSetting levelSetting)
        {
            _factory = factory;
            _gridData = levelSetting.GridData;
        }

        public Cell[][] GetCells()
        {
            if (_cells is null)
                throw new NullReferenceException("Cells is null");

            return _cells;
        }

        public void Start()
        {
            CreateGrid();
        }

        public void CreateGrid()
        {
            Vector3 middlePosition = CalculateMiddlePosition();
            _cells = new Cell[_gridData.GridLines.Count][];
            for (int x = 0; x < _gridData.GridLines.Count; x++)
            {
                _cells[x] = new Cell[_gridData.GridLines[x].Cells.Count];
                for (int y = 0; y < _gridData.GridLines[x].Cells.Count; y++)
                {
                    Vector3 cellPosition =
                        new Vector3(x * _gridData.CellOffset, 0, y * _gridData.CellOffset) - middlePosition + _parrent.transform.position;
                    _cells[x][y] =
                        _factory.CreateObject<Cell>($"Cell_{_gridData.GridLines[x].Cells[y].CellType}", cellPosition, _parrent.transform);
                }
            }
        }

        public void RemoveGrid()
        {
            foreach (Cell[] cellLine in _cells)
            {
                if (cellLine is not null)
                    foreach (Cell cells in cellLine)
                    {
                        if (cells is not null)
                            DestroyImmediate(cells.gameObject);
                    }
            }

            _cells = null;
        }

        private Vector3 CalculateMiddlePosition()
        {
            Vector2Int gridSize = new Vector2Int(_gridData.GridLines.Count, 0);
            for (int x = 0; x < gridSize.x; x++)
            {
                int countCells = _gridData.GridLines[x].Cells.Count;
                if (gridSize.y < countCells)
                    gridSize.y = countCells;
            }

            float gridWidth = gridSize.x * _gridData.CellOffset - _gridData.CellOffset;
            float gridHeight = gridSize.y * _gridData.CellOffset - _gridData.CellOffset;
            return new Vector3(gridWidth, 0, gridHeight) / 2;
        }
    }
}