using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork4WithLogin.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public DateTime? Birthday { get; set; }
        [Required(ErrorMessage = "*")]
        public bool? Gender { get; set; }
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        public string Image { get; set; }
        public IFormFile UploadImage { get; set; }//image
    }
}
