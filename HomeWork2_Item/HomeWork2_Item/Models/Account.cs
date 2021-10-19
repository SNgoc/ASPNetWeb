using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWork2_Item.Models
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
