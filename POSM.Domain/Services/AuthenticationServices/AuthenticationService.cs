using Microsoft.AspNet.Identity;
using POSM.Domain.Exceptions;
using POSM.EntityFramework.Models;
using System;
using System.Threading.Tasks;

namespace POSM.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string username, string password)
        {
			User storedAccount = await _accountService.GetByUsername(username);

			if (storedAccount == null)
			{
				throw new UserNotFoundException(username);
			}

			PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.PasswordHash, password);

			if (passwordResult != PasswordVerificationResult.Success)
			{
				throw new InvalidPasswordException(username, password);
			}

			return storedAccount;
        }
    }
}
