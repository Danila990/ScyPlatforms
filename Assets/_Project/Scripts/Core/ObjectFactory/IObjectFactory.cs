using UnityEngine;

namespace MyCode.Core
{
    public interface IObjectFactory
    {
        public T CreateObject<T>(string key, Vector3 position = default, Transform parent = null, bool isActive = true) where T : MonoBehaviour;
        public GameObject CreateObject(string key, Vector3 position = default, Transform parent = null, bool isActive = true);
    }
}
