using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWeb.Models.DTO
{
    public class ProductDTO
    {
        [Required]//annotation
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Price { get; set; }//? giống Nullable type
        public string Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }
}
