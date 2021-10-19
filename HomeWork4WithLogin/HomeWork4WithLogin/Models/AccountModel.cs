using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork4WithLogin.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage ="*")]
        public string Username { get; set; }
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
    }
}
