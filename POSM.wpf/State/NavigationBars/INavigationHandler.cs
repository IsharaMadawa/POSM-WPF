using System;

namespace POSM.wpf.State.Authenticators
{
	public interface INavigationHandler
	{
		public event Action<bool> showNavigationBar;
		void UpdateNavBarStatus(bool isActivate);
	}
}
