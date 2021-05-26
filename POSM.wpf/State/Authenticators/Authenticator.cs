using POSM.Domain.Services.AuthenticationServices;
using POSM.EntityFramework.Models;
using POSM.wpf.State.Accounts;
using System;
using System.Threading.Tasks;

namespace POSM.wpf.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;
        public bool IsLoggedIn => CurrentAccount != null;
        public event Action StateChanged;

        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }

		public User CurrentAccount
		{
			get
			{
                return _accountStore.CurrentAccount;
			}
			private set
			{
				_accountStore.CurrentAccount = value;
				StateChanged?.Invoke();
			}
		}

        public async Task Login(string username, string password)
        {
            CurrentAccount = await _authenticationService.Login(username, password);
        }

        public void Logout()
        {
            CurrentAccount = null;
        }
    }
}
