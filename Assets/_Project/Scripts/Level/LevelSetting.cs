using MyCode.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode 
{
    [CreateAssetMenu(menuName = "LevelSetting", fileName = nameof(LevelSetting))]
    public class LevelSetting : ScriptableObject
    {
        [field: SerializeField] public int LevelDuration { get; private set; } = 30;
        [field: SerializeField] public GridData GridData { get; private set; }
    }
}