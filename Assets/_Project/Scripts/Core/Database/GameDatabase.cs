using UnityEngine;

namespace MyCode.Core
{
    [CreateAssetMenu(menuName = "GameDatabase", fileName = nameof(GameDatabase))]
    public class GameDatabase : ScriptableObject, IDatabase
    {
        [SerializeField] private DataContainer<GameObject> _objects;
        [SerializeField] private DataContainer<ScriptableObject> _scriptableObject;

        public GameObject GetObject(string key)
        {
            return _objects.GetData(key);
        }

        public T GetObject<T>(string key) where T : MonoBehaviour
        {
            return GetObject(key).GetComponent<T>();
        }

        public T GetSO<T>(string key) where T : ScriptableObject
        {
            return (T)_scriptableObject.GetData(key);
        }
    }
}
