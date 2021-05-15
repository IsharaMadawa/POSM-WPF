using POSM.EntityFramework.Models;
using System;

namespace POSM.wpf.State.Accounts
{
    public interface IAccountStore
    {
        Account CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
