using System;
using System.Collections.Generic;

#nullable disable

namespace ProductWeb.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
    }
}
