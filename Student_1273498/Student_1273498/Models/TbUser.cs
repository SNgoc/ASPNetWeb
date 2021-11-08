using System;
using System.Collections.Generic;

#nullable disable

namespace Student_1273498.Models
{
    public partial class TbUser
    {
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
