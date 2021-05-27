using POSM.wpf.ViewModels;
using System;

namespace POSM.wpf.State.Navigators
{
    public enum ViewType
    {
        Login,
        Home,
        Billing,
        Settings,
        BillingSettings,
        About
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
