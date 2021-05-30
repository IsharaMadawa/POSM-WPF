using POSM.EntityFramework.Models;
using System;

namespace POSM.wpf.State.Users
{
    public interface IUserStore
    {
        User CurrentUser { get; set; }
        event Action StateChanged;
    }
}
