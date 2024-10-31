using System;
using VContainer.Unity;

namespace MyCode
{
    public interface IInputService : ITickable
    {
        public void Activate();
        public void Deactivate();
    }
}