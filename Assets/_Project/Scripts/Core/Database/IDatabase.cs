using UnityEngine;

namespace MyCode.Core
{
    public interface IDatabase
    {
        public GameObject GetObject(string key);
        public T GetObject<T>(string key) where T : MonoBehaviour;
        public T GetSO<T>(string key) where T : ScriptableObject;
    }
}
