using POSM.EntityFramework.Models;
using System;

namespace POSM.wpf.State.Accounts
{
    public interface IUserStore
    {
        User CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
