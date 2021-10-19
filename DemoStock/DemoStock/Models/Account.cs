using System;
using System.Collections.Generic;

#nullable disable

namespace DemoStock.Models
{
    public partial class Account
    {
        public Account()
        {
            Items = new HashSet<Item>();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
