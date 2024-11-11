using MyCode.Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelSetting _levelSetting;
        [SerializeField] private GridCreator _gridCreator;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(_levelSetting);
            builder.RegisterComponent(_gridCreator).As<IStartable>();
        }
    }
}