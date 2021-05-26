using POSM.wpf.Commands;
using POSM.wpf.State.Authenticators;
using POSM.wpf.State.Navigators;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
	public class BillingViewModel : ViewModelBase
	{
        public MessageViewModel ErrorMessageViewModel { get; }
        private readonly INavigationHandler _navigationHandler;
        public ICommand ViewHomeCommand { get; }
        public ICommand ButtonCommand { get; set; }
        //private ICommand m_ButtonCommand;
        //public ICommand MVVMClick
        //{
        //    get { return m_ButtonCommand; }
        //    set { m_ButtonCommand = value; }
        //}
        private bool _isShowNav;
        public bool isShowNav
        {
            get { return _isShowNav; }
            set
            {
                _isShowNav = value;
                OnPropertyChanged("isShowNav");
            }
        }

        public BillingViewModel(IRenavigator HomeRenavigator, INavigationHandler navigationHandler)
        {
            _navigationHandler = navigationHandler;
            ErrorMessageViewModel = new MessageViewModel();

            ViewHomeCommand = new RenavigateCommand(HomeRenavigator);
            ButtonCommand = new RelayCommand(this, navigationHandler);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

    }
}
