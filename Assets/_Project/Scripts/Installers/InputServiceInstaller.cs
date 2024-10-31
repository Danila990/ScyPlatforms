using MyCode.Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode
{
    public class InputServiceInstaller : MonoInstaller
    {
        [SerializeField] private bool _isPcTest = true;

        public override void Install(IContainerBuilder builder)
        {
            if (_isPcTest)
                builder.Register<IInputService, PcInputService>(Lifetime.Singleton).As<ITickable>();
            else
                builder.Register<IInputService, MobileInputService>(Lifetime.Singleton).As<ITickable>();
        }
    }
}