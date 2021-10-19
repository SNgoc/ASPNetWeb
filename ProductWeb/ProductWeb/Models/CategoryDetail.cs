using System;
using System.Collections.Generic;

#nullable disable

namespace ProductWeb.Models
{
    public partial class CategoryDetail
    {
        public CategoryDetail()
        {
            Books = new HashSet<Book>();
        }

        public string CatCode { get; set; }
        public string CatDescription { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
