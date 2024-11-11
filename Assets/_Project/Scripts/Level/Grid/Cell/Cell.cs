using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public class Cell : MonoBehaviour
    {
        [field: SerializeField] public CellInfo CellInfo { get; private set; }

        public void SetCellInfo(CellInfo cellInfo) => CellInfo = cellInfo;
    }
}