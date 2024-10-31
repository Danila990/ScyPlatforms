using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace MyCode.Core
{
    public class ObjectFactory : IObjectFactory
    {
        private readonly IDatabase _database;
        private readonly IObjectResolver _objectResolver;

        public ObjectFactory(IObjectResolver objectResolver, IDatabase database)
        {
            _database = database;
            _objectResolver = objectResolver;
        }

        public T CreateObject<T>(string key, Vector3 position = default, bool isActive = true) where T : MonoBehaviour
        {
            return CreateObject(key, position, isActive).GetComponent<T>();
        }

        public GameObject CreateObject(string key, Vector3 position = default, bool isActive = true)
        {
            var createObject = Object.Instantiate(_database.GetData<GameObject>(key));
            createObject.transform.position = position;
            createObject.gameObject.SetActive(isActive);
            _objectResolver.Inject(createObject);
            return createObject;
        }
    }
}
