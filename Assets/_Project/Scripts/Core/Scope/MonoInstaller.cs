using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
	public abstract class MonoInstaller : MonoBehaviour, IInstaller
	{
		public abstract void Install(IContainerBuilder builder);
	}
}