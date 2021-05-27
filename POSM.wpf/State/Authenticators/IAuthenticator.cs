﻿using POSM.Domain.Services.AuthenticationServices;
using POSM.EntityFramework.Models;
using System;
using System.Threading.Tasks;

namespace POSM.wpf.State.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentAccount { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        /// <summary>
        /// Login to the application.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task Login(string username, string password);

        void Logout();
    }
}
