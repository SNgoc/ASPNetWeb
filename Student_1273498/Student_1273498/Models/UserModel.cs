using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_1273498.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Fullname { get; set; }
        [Required(ErrorMessage = "*")]
        public string Username { get; set; }
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
