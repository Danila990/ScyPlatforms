using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyCode.Core
{
    [Serializable]
    public class ObjectContainer<T> where T : Object
    {
        [Serializable]
        private struct ObjectData
        {
            public string Key;
            public T Data;
        }

        [SerializeField] private ObjectData[] _objectsData;

        public T GetData(string key)
        {
            foreach (var data in _objectsData)
            {
                if (data.Key.Equals(key))
                    return data.Data;
            }

            throw new NullReferenceException($"Not find object: Name - {nameof(T)}, Key - {key}");
        }
    }
}