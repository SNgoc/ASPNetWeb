using System;
using System.Collections.Generic;

#nullable disable

namespace BookManager.Models
{
    public partial class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }
        public string Image { get; set; }
    }
}
