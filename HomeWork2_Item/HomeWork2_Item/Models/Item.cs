using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWork2_Item.Models
{
    public partial class Item
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int? Price { get; set; }
        public string Image { get; set; }
        public string Username { get; set; }

        public virtual Account UsernameNavigation { get; set; }
    }
}
