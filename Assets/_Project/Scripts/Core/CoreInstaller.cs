using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
    [CreateAssetMenu(menuName = "CoreInstaller", fileName = nameof(CoreInstaller))]
    public class CoreInstaller : MonoInstaller
    {
        [SerializeField] private GameDatabase _database;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent<IDatabase>(_database);
            builder.Register<IObjectFactory, ObjectFactory>(Lifetime.Singleton);
        }
    }
}