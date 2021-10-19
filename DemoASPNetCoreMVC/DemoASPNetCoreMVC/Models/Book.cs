using System;
using System.Collections.Generic;

#nullable disable

namespace DemoASPNetCoreMVC.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }
        public string CatId { get; set; }

        public virtual CategoryDetail Cat { get; set; }
    }
}
