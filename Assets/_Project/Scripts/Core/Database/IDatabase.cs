using UnityEngine;

namespace MyCode.Core
{
    public interface IDatabase
    {
        public T GetData<T>(string key) where T : Object;
    }
}
