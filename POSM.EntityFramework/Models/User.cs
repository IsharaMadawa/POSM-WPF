using System;
using System.Collections.Generic;

#nullable disable

namespace POSM.EntityFramework.Models
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateJoined { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
