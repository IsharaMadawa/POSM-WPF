using POSM.EntityFramework.Models;
using System;

namespace POSM.wpf.State.Accounts
{
    public class UserStore : IUserStore
    {
        private User _currentAccount;
        public User CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;

    }
}
