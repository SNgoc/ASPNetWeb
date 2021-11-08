using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Models
{
    public class BookModel
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }
        public string Image { get; set; }
        public IFormFile UploadImage { get; set; }//upload image
        public string ImagePath { get; set; } // dùng cho mục đích display image trong phần update
    }
}
