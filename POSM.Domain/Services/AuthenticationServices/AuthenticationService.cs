using Microsoft.AspNet.Identity;
using POSM.Domain.Exceptions;
using POSM.EntityFramework.Models;
using System.Threading.Tasks;

namespace POSM.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IUserService userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string username, string password)
        {
			User storedUser = await _userService.GetByUsername(username);

			if (storedUser == null)
			{
				throw new UserNotFoundException(username);
			}

			PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedUser.PasswordHash, password);

			if (passwordResult != PasswordVerificationResult.Success)
			{
				throw new InvalidPasswordException(username, password);
			}

			return storedUser;
        }
    }
}
