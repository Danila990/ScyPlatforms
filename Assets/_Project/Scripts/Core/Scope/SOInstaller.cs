using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
	public abstract class SOInstaller : ScriptableObject, IInstaller
	{
		public abstract void Install(IContainerBuilder builder);
	}
}