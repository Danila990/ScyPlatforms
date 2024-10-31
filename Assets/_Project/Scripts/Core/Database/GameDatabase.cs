using UnityEngine;

namespace MyCode.Core
{
    [CreateAssetMenu(menuName = "GameDatabase", fileName = nameof(GameDatabase))]
    public class GameDatabase : ScriptableObject, IDatabase
    {
        [SerializeField] private ObjectContainer<Object> _container;

        public T GetData<T>(string key) where T : Object
        {
            return (T)_container.GetData(key);
        }
    }
}
