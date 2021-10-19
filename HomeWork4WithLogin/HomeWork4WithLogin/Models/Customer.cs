using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWork4WithLogin.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
