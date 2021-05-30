using System;
using System.Collections.Generic;

#nullable disable

namespace POSM.EntityFramework.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
