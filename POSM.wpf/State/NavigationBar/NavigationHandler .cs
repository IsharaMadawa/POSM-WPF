using POSM.wpf.State.Authenticators;
using System;

namespace POSM.wpf.Stores
{
	public class NavigationHandler : INavigationHandler
	{
		public event Action<bool> showNavigationBar;
		public event Action StateChanged;

		public void UpdateNavBarStatus(bool isActivate)
		{
			showNavigationBar?.Invoke(isActivate);
		}
	}
}
