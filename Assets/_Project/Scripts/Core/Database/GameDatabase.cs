using System.Collections.Generic;
using UnityEngine;

namespace MyCode.Core
{
    [CreateAssetMenu(menuName = "GameDatabase", fileName = nameof(GameDatabase))]
    public class GameDatabase : ScriptableObject, IDatabase
    {
        [SerializeField] private ObjectContainer<Object> _container;

        private Dictionary<string, object> _datas = new Dictionary<string, object>();

        public T GetData<T>(string key) where T : Object
        {
            if (_datas.ContainsKey(key))
                return _datas[key] as T;

            _datas.Add(key, _container.GetData(key));
            return _datas[key] as T;
        }
    }
}
