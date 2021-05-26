using System;

namespace POSM.wpf.State.Authenticators
{
	public interface INavigationHandler
	{
		event Action StateChanged;
		public event Action<bool> showNavigationBar;
		void UpdateNavBarStatus(bool isActivate);
	}
}
