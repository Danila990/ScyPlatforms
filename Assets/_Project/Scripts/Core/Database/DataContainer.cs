using System;
using UnityEngine;

namespace MyCode.Core
{
    [Serializable]
    public class DataContainer<T>
    {
        [Serializable]
        private struct ObjectData
        {
            public string Key;
            public T Object;
        }

        [SerializeField] private ObjectData[] _objectDatas;

        public T GetData(string key)
        {
            foreach (var data in _objectDatas)
            {
                if (data.Key.Equals(key))
                    return data.Object;
            }

            throw new NullReferenceException($"Find {nameof(T)} is null");
        }
    }
}