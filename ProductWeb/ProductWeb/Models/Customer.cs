using System;
using System.Collections.Generic;

#nullable disable

namespace ProductWeb.Models
{
    public partial class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
    }
}
