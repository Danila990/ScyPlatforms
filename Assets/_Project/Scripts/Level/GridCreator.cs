using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GridCreator : MonoBehaviour
{
    [Serializable]
    private class GridLine
    {
        public List<Cell> Line = new List<Cell>();
    }

    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private float _cellsOffset = 3.2f;
    [SerializeField] private Transform _parrent;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private List<GridLine> _gridLines = new List<GridLine>();

    public void GenerateGrid()
    {
        CreateCells();
        SetupCellsPosition();
    }

    private void SetupCellsPosition()
    {
        Vector3 middlePosition = CalculateMiddlePosition();
        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                Vector3 cellPosition = new Vector3(x * _cellsOffset, 0, y * _cellsOffset) - middlePosition + _parrent.transform.position;
                _gridLines[x].Line[y].transform.position = cellPosition;
            }
        }
    }

    private void CreateCells()
    {
        _gridLines.Clear();
        for (int x = 0; x < _gridSize.x; x++)
        {
            GridLine gridLine = new GridLine();
            for (int y = 0; y < _gridSize.y; y++)
            {
                Cell cell = Instantiate(_cellPrefab, _parrent.transform);
                gridLine.Line.Add(cell);
            }

            _gridLines.Add(gridLine);
        }
    }

    private Vector3 CalculateMiddlePosition()
    {
        float gridWidth = _gridSize.x * _cellsOffset - _cellsOffset;
        float gridHeight = _gridSize.y * _cellsOffset - _cellsOffset;
        return new Vector3(gridWidth, 0, gridHeight) / 2;
    }


#if UNITY_EDITOR

    public void RemoveGrid()
    {
        foreach (var gridLine in _gridLines)
        {
            if (gridLine is null)
                break;

            foreach (var line in gridLine.Line)
            {
                if (line is null)
                    break;

                DestroyImmediate(line.gameObject);
            }

            gridLine.Line.Clear();
        }

        _gridLines.Clear();
    }

    [CustomEditor(typeof(GridCreator))]
    public class GridCreatorCustomEditor : Editor
    {
        private GridCreator _gridCreator;

        private void OnEnable()
        {
            _gridCreator = (GridCreator)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Create Grid", GUILayout.Height(20)))
            {
                _gridCreator.RemoveGrid();
                _gridCreator.GenerateGrid();
                EditorUtility.SetDirty(_gridCreator);
                AssetDatabase.SaveAssets();
            }

            if (GUILayout.Button("Remove Grid", GUILayout.Height(20)))
            {
                _gridCreator.RemoveGrid();
                EditorUtility.SetDirty(_gridCreator);
                AssetDatabase.SaveAssets();
            }
        }
    }
#endif
}
