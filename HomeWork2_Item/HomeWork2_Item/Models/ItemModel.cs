using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork2_Item.Models
{
    public class ItemModel
    {
        [Required(ErrorMessage = "*")]
        public string ItemCode { get; set; }
        [Required(ErrorMessage = "*")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "*")]
        public int? Price { get; set; }
        public IFormFile UploadImage { get; set; }//image
        public string Username { get; set; }
    }
}
