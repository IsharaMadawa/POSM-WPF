using System;
using System.Collections.Generic;

#nullable disable

namespace POSM.EntityFramework.Models
{
    public partial class Account
    {
        public int Id { get; set; }

        public virtual User IdNavigation { get; set; }
    }
}
