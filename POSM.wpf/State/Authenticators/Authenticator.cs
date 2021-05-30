using POSM.Domain.Services.AuthenticationServices;
using POSM.EntityFramework.Models;
using POSM.wpf.State.Users;
using System;
using System.Threading.Tasks;

namespace POSM.wpf.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserStore _userStore;
        public bool IsLoggedIn => CurrentUser != null;
        public event Action StateChanged;

        public Authenticator(IAuthenticationService authenticationService, IUserStore userStore)
        {
            _authenticationService = authenticationService;
            _userStore = userStore;
        }

		public User CurrentUser
        {
			get
			{
                return _userStore.CurrentUser;
			}
			private set
			{
                _userStore.CurrentUser = value;
				StateChanged?.Invoke();
			}
		}

        public async Task Login(string username, string password)
        {
            CurrentUser = await _authenticationService.Login(username, password);
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
